using UnityEngine;
using scr = Assets.Scripts;
namespace Assets.Blocks
{
    public class UnMovableBlock : Block
    {
        scr.Color Color { get; set; }
        public UnMovableBlock(Vector3 coordinateOnBoard)
        {
            Filled = true;
            CoordinateOnBoard = CalculateCoordinates(coordinateOnBoard);
        }
        public override Color GetRGBColor()
        {
            return new UnityEngine.Color(0, 0, 0);
        }
        public override void ReactionOnClick()
        {
        }
    }
}
