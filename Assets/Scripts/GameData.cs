using Assets.Blocks;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    static class GameData
    {
        public const int COUNT_ARROWS=4;
        private static Dictionary<Vector2, Block> gameField;

        static GameData()
        {
            //Arrows = new GameObject[COUNT_ARROWS];
            gameField = new Dictionary<Vector2, Block>();
        }

       public static void AddBlockOnGamefield(Block block)
        {
            float x = Mathf.Round((block.CoordinateOnBoard.x - Configuration.GAMEFIELD_OFFSET.x)
                / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            float y = Mathf.Round((block.CoordinateOnBoard.y - Configuration.GAMEFIELD_OFFSET.y)
                / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            GameField.Add(new Vector2(x, y), block);
        }
       public static void ClearGamefield()
        {
            GameField.Clear();
        }
      
        public static Block TryFindBlock(Vector2 coordinate)
        {
            Block result;
            float x =Mathf.Round((coordinate.x-Configuration.GAMEFIELD_OFFSET.x)
                / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            float y = Mathf.Round((coordinate.y - Configuration.GAMEFIELD_OFFSET.y)
                / Configuration.DISTANCE_FROM_CENTERS_BLOCKS);
            GameField.TryGetValue(new Vector2(x,y),out result);
            return result;
        }
        public static Arrow TryFindArrow(Vector3 coordinate)
        {
            for (int i=0;i<Arrows.Length;i++)
            {
                if (Arrows[i].arrow.transform.position == coordinate)
                    return Arrows[i];
            }
            return null;
        }
        public static void SwapBlocks(Block block,Direction directionSecondBlock)
        {
            float x=0;
            float y=0;
            switch (directionSecondBlock)
            {
                case Direction.Left:x += -1;break;
                case Direction.Right:x += 1;break;
                case Direction.Up:y += 1;break;
                case Direction.Down:y += -1;break;
            }
            Block secondBlock = TryFindBlock(new Vector2(
                block.Object.transform.position.x + x * Configuration.DISTANCE_FROM_CENTERS_BLOCKS,
                block.Object.transform.position.y + y * Configuration.DISTANCE_FROM_CENTERS_BLOCKS));
            GameField.Remove(new Vector2(Mathf.Round((block.CoordinateOnBoard.x-Configuration.GAMEFIELD_OFFSET.x)
                /Configuration.DISTANCE_FROM_CENTERS_BLOCKS)
                ,Mathf.Round((block.CoordinateOnBoard.y - Configuration.GAMEFIELD_OFFSET.y) 
                / Configuration.DISTANCE_FROM_CENTERS_BLOCKS)));
            GameField.Remove(new Vector2(Mathf.Round((secondBlock.CoordinateOnBoard.x - Configuration.GAMEFIELD_OFFSET.x)
              / Configuration.DISTANCE_FROM_CENTERS_BLOCKS)
              , Mathf.Round((secondBlock.CoordinateOnBoard.y - Configuration.GAMEFIELD_OFFSET.y)
              / Configuration.DISTANCE_FROM_CENTERS_BLOCKS)));
            Vector3 position = block.Object.transform.position;
            block.Object.transform.position = secondBlock.Object.transform.position;
            secondBlock.Object.transform.position = position;
            block.CoordinateOnBoard = block.Object.transform.position;
            secondBlock.CoordinateOnBoard = secondBlock.Object.transform.position;
            AddBlockOnGamefield(block);
            AddBlockOnGamefield(secondBlock);
        }      
        // public static Block[,] GameField { get; set; }
        public static int WidthField { set; get; }
        public static int HeightField { set; get; }
        public static Arrow[] Arrows { get; set; }
        public static Goal[] Goals { get;set; }
        
        public static Dictionary<Vector2, Block> GameField
        {
            get { return gameField; }
        }

    }

}
