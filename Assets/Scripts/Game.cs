using Assets.Blocks;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject gameField;
    // Use this for initialization
    void Start()
    {
        Level1.LoadLevel();
        Draw ds = this.GetComponent<Draw>();
        ds.Initialize(gameField);

    }
    private void FixedUpdate()
    {
        bool goalIsAchieved = true; ;
        foreach (Block block in GameData.GameField.Values)
        {
            for (int i=0;i<GameData.Goals.Length;i++)
            {
                if (block is ColorBlock)
                {
                    if ((Mathf.Round(block.CoordinateOnBoard.x/
                        Configuration.DISTANCE_FROM_CENTERS_BLOCKS)
                        != GameData.Goals[i].Position.x)
                        ||((ColorBlock)block).Color!=GameData.Goals[i].Color)
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
            SceneManager.LoadScene(1);
                
        }
    }
}
