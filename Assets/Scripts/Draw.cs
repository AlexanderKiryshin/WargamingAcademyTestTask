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
            foreach (Block block in GameField.Board.Values)
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
            for (int i = 0; i < GameField.COUNT_ARROWS; i++)
            {
                arrows[i] = new Arrow();
                arrows[i].arrow = Instantiate(arrow, new Vector3(0, 0, -2), new Quaternion(0, 0, 0, 0));
                arrows[i].arrow.transform.Rotate(new Vector3(0, 0, i * 90));
                arrows[i].arrow.transform.parent = gameField.transform;
                arrows[i].arrow.SetActive(false);
            }
            GameField.Arrows = arrows;
            for (int i=0;i<GameField.Goals.Length;i++)
            {
                Vector3 vector = new Vector3(GameField.Goals[i].Position.x *Configuration.DISTANCE_FROM_CENTERS_BLOCKS
                    + Configuration.GOAL_OFFSET.x,
                    (GameField.Goals[i].Position.y-1) *Configuration.DISTANCE_FROM_CENTERS_BLOCKS+ 
                   Configuration.GOAL_DIAMETER + Configuration.GOAL_OFFSET.y, -2);
                GameField.Goals[i].Object= Instantiate(goal, vector, new Quaternion(0, 0, 0, 0));
                SpriteRenderer sr = GameField.Goals[i].Object.GetComponent<SpriteRenderer>();
                sr.color = GameField.Goals[i].GetRGBColor();
            }
        }
        public static void HideArrows()
        {
            for (int i = 0; i < GameField.COUNT_ARROWS; i++)
            {
                GameField.Arrows[i].arrow.SetActive(false);
            }
            // Update is called once per frame
        }
        public static void ShowBlueArrow(int index)
        {
            GameField.Arrows[index].arrow.SetActive(true);
            SpriteRenderer sr = GameField.Arrows[index].arrow.GetComponent<SpriteRenderer>();
            sr.color = UnityEngine.Color.blue;
        }
        public static void ShowGrayArrow(int index)
        {
            GameField.Arrows[index].arrow.SetActive(true);
            SpriteRenderer sr = GameField.Arrows[index].arrow.GetComponent<SpriteRenderer>();
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
            Block block = GameField.TryFindBlock(new Vector2(coordinateBlock.x + x*Configuration.DISTANCE_FROM_CENTERS_BLOCKS,
                coordinateBlock.y + y*Configuration.DISTANCE_FROM_CENTERS_BLOCKS));
            if ((block != null) && (block.Filled == false))
            {
                GameField.Arrows[index].isActive = true;
                Draw.ShowBlueArrow(index);
            }
            else
            {
                GameField.Arrows[index].isActive = false;
                Draw.ShowGrayArrow(index);
            }
            GameField.Arrows[index].arrow.transform.position = new Vector3(
                    coordinateBlock.x+x*Configuration.DISTANCE_ARROW_FROM_CENTR_BLOCK,
                     coordinateBlock.y + y * Configuration.DISTANCE_ARROW_FROM_CENTR_BLOCK,
                    coordinateBlock.z - 1);
        }
        
    }
}

