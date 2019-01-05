using Assets.Blocks;
using UnityEngine;

namespace Assets.Scripts
{
    class Draw : MonoBehaviour
    {
        private const int COUNT_ARROWS = 4;
        [SerializeField]
        private GameObject filledBlock;
        [SerializeField]
        private GameObject emptyBlock;
        [SerializeField]
        private GameObject arrow;
        [SerializeField]
        private GameObject goal;
        public void Initialize(GameObject gameField)
        {
            foreach (Block block in GameData.GameField.Values)
            {
                if (block.Filled)
                {
                    block.Object = Instantiate(filledBlock, block.CoordinateOnBoard * Block.BLOCK_WIDTH, Quaternion.identity);
                    SpriteRenderer sr = block.Object.GetComponent<SpriteRenderer>();
                    sr.color = block.GetRGBColor();
                }
                else
                {
                    block.Object = Instantiate(emptyBlock, block.CoordinateOnBoard * Block.BLOCK_WIDTH, Quaternion.identity);
                }
                block.Object.transform.parent = gameField.transform;
                block.Object.name = block.ToString();
            }
            Arrow[] arrows = new Arrow[COUNT_ARROWS];
            for (int i = 0; i < GameData.COUNT_ARROWS; i++)
            {
                arrows[i] = new Arrow();
                arrows[i].arrow = Instantiate(arrow, new Vector3(0, 0, -2), new Quaternion(0, 0, 0, 0));
                arrows[i].arrow.transform.Rotate(new Vector3(0, 0, i * 90));
                arrows[i].arrow.transform.parent = gameField.transform;
                arrows[i].arrow.SetActive(false);
            }
            GameData.Arrows = arrows;
            for (int i=0;i<GameData.Goals.Length;i++)
            {
                Vector3 vector = new Vector3(GameData.Goals[i].Position.x *Configuration.DISTANCE_FROM_CENTERS_BLOCKS
                    + Configuration.GOAL_OFFSET.x,
                    (GameData.Goals[i].Position.y-1) *Configuration.DISTANCE_FROM_CENTERS_BLOCKS+ 
                   Configuration.GOAL_DIAMETER + Configuration.GOAL_OFFSET.y, -2);
                GameData.Goals[i].Object= Instantiate(goal, vector, new Quaternion(0, 0, 0, 0));
                SpriteRenderer sr = GameData.Goals[i].Object.GetComponent<SpriteRenderer>();
                sr.color = GameData.Goals[i].GetRGBColor();
            }
        }
        public static void HideArrows()
        {
            for (int i = 0; i < GameData.COUNT_ARROWS; i++)
            {
                GameData.Arrows[i].arrow.SetActive(false);
            }
            // Update is called once per frame
        }
        public static void ShowBlueArrow(int index)
        {
            GameData.Arrows[index].arrow.SetActive(true);
            SpriteRenderer sr = GameData.Arrows[index].arrow.GetComponent<SpriteRenderer>();
            sr.color = UnityEngine.Color.blue;
        }
        public static void ShowGrayArrow(int index)
        {
            GameData.Arrows[index].arrow.SetActive(true);
            SpriteRenderer sr = GameData.Arrows[index].arrow.GetComponent<SpriteRenderer>();
            sr.color = UnityEngine.Color.gray;
        }
        public static void ActivateArrow(Direction direction, Vector3 coordinateBlock)
        {
            float x = 0;// Mathf.Round((coordinateBlock.x - Configuration.GAMEFIELD_OFFSET.x) / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            float y = 0;// Mathf.Round((coordinateBlock.y - Configuration.GAMEFIELD_OFFSET.y) / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            int index = 0;
            switch (direction)
            {
                case Direction.Left:
                    x += -1;
                    index = 2;
                    break;
                case Direction.Right:
                    x += 1;
                   
                    break;
                case Direction.Up:
                    y += 1;
                    index = 1;
                    break;
                case Direction.Down:
                    y += -1;
                    index = 3;
                    break;
            }
            Block block = GameData.TryFindBlock(new Vector2(coordinateBlock.x + x*Configuration.DISTANCE_FROM_CENTERS_BLOCKS,
                coordinateBlock.y + y*Configuration.DISTANCE_FROM_CENTERS_BLOCKS));
            if ((block != null) && (block.Filled == false))
            {
                GameData.Arrows[index].isActive = true;
                Draw.ShowBlueArrow(index);
            }
            else
            {
                GameData.Arrows[index].isActive = false;
                Draw.ShowGrayArrow(index);
            }
            GameData.Arrows[index].arrow.transform.position = new Vector3(
                    coordinateBlock.x+x*Configuration.DISTANCE_ARROW_FROM_CENTR_BLOCK,
                     coordinateBlock.y + y * Configuration.DISTANCE_ARROW_FROM_CENTR_BLOCK,
                    coordinateBlock.z - 1);
        }
        
    }
}

