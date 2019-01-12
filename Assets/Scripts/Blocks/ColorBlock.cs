using scr = Assets.Scripts;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

namespace Assets.Blocks
{
    public class ColorBlock : Block
    {
        public ColorBlock(scr.Color color, Vector3 coordinateOnBoard)
        {
            Filled = true;
            CoordinateOnBoard = CalculateCoordinates(coordinateOnBoard);
            Color = color;
        }

        public override void ReactionOnClick()
        {
            Draw.ActivateArrow(Direction.Left, CoordinateOnBoard);
            Draw.ActivateArrow(Direction.Right, CoordinateOnBoard);
            Draw.ActivateArrow(Direction.Up, CoordinateOnBoard);
            Draw.ActivateArrow(Direction.Down, CoordinateOnBoard);
        }
        
        public override UnityEngine.Color GetRGBColor()
        {
            switch (Color)
            {
                case scr.Color.Green: return new UnityEngine.Color(0,255,0);
                case scr.Color.Yellow: return new UnityEngine.Color(255, 255, 0);
                case scr.Color.Red: return new UnityEngine.Color(255, 0, 0);
                default:return new UnityEngine.Color();
            }
        }
        private void AddAdjacentBlock(ref List<Block> adjacentBlocks, Vector3 coordinate)
        {
            Block result = GameField.TryFindBlock(coordinate);
            if (result != null)
            {
                adjacentBlocks.Add(result);
            }
        }
        public scr.Color Color { get; set; }
    }
}
