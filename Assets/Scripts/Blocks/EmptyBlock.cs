using UnityEngine;

namespace Assets.Blocks
{
    class EmptyBlock : Block
    {
        public EmptyBlock(Vector3 coordinateOnBoard)
        {
            Filled = false;
            CoordinateOnBoard = CalculateCoordinates(coordinateOnBoard);
        }
        public override Color GetRGBColor()
        {
            throw new System.NotImplementedException();
        }

        public override void ReactionOnClick()
        {
            throw new System.NotImplementedException();
        }
    }
}
