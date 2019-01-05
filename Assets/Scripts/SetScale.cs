using UnityEngine;

public class SetScale : MonoBehaviour {
    private const int MIN_RESOLUTION=600;
    [SerializeField]
    private float scaleCoef;

	// Use this for initialization
	void Start () {
        int minResolution = Screen.height <= Screen.width ? Screen.height : Screen.width;
        float scale = (float)minResolution / (float)(MIN_RESOLUTION) * scaleCoef;
        this.transform.localScale = new Vector3(scale, scale);           
	}
}