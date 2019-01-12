using Assets.Blocks;
using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject gameField;
    [SerializeField]
    private GameObject text;

    // Use this for initialization
    void Start()
    {
        Level1.LoadLevel();
        Draw ds = this.GetComponent<Draw>();
        ds.Initialize(gameField);

    }

    private void FixedUpdate()
    {
        bool goalIsAchieved = true;
        foreach (Block block in GameField.Board.Values)
        {
            for (int i = 0; i < GameField.Goals.Length; i++)
            {
                if (block is ColorBlock)
                {
                    if ((Mathf.Round(block.CoordinateOnBoard.x /
                        Configuration.DISTANCE_FROM_CENTERS_BLOCKS)
                        != GameField.Goals[i].Position.x)
                        || ((ColorBlock)block).Color != GameField.Goals[i].Color)
                    {
                        goalIsAchieved = false;
                    }
                    else
                    {
                        goalIsAchieved = true;
                        break;
                    }
                }
            }
            if (!goalIsAchieved)
            {
                break;
            }
        }
        if (goalIsAchieved)
        {
            StartCoroutine(EndLevel());
        }
    }

    public IEnumerator EndLevel()
    {
        StartCoroutine(ScreenFader.FadeSceneOut());
        yield return new WaitForSeconds(0.6f);
        text.SetActive(true);
    }
}

