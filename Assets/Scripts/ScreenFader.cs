using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public enum FadeType
    {
        Black, Loading, GameOver,
    }

    public static ScreenFader Instance
    {
        get
        {
            if (s_Instance != null)
                return s_Instance;

            s_Instance = FindObjectOfType<ScreenFader>();

            if (s_Instance != null)
                return s_Instance;

            Create();

            return s_Instance;
        }
    }

    public static bool IsFading
    {
        get { return Instance.m_IsFading; }
    }

    protected static ScreenFader s_Instance;

    public static void Create()
    {
        ScreenFader controllerPrefab = Resources.Load<ScreenFader>("ScreenFader");
        s_Instance = Instantiate(controllerPrefab);
    }


    public CanvasGroup faderCanvasGroup;
    public float fadeDuration = 1f;

    protected bool m_IsFading;

    const int k_MaxSortingLayer = 15000;

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    protected IEnumerator Fade(float finalAlpha, CanvasGroup canvasGroup)
    {
        m_IsFading = true;
        canvasGroup.blocksRaycasts = true;
        float fadeSpeed = Mathf.Abs(canvasGroup.alpha - finalAlpha) / fadeDuration;
        while (!Mathf.Approximately(canvasGroup.alpha, finalAlpha))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, finalAlpha,
                fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
        }
        canvasGroup.alpha = finalAlpha;
        m_IsFading = false;
        canvasGroup.blocksRaycasts = false;
    }

    public static void SetAlpha(float alpha)
    {
        Instance.faderCanvasGroup.alpha = alpha;
    }

    public static IEnumerator FadeSceneOut(FadeType fadeType = FadeType.Black)
    {
        Instance.faderCanvasGroup.gameObject.SetActive(true);

        yield return Instance.StartCoroutine(Instance.Fade(1f, Instance.faderCanvasGroup));
    }
}