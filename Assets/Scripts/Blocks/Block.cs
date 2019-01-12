using Assets.Scripts;
using UnityEngine;

namespace Assets.Blocks
{
    public abstract class Block
    {
        private Vector3 coordinateOnBoard;
        public const float BLOCK_WIDTH = 1f;
        public Vector3 CalculateCoordinates(Vector3 coordinates)
        {
            return new Vector3(coordinates.x * Configuration.DISTANCE_FROM_CENTERS_BLOCKS
                + Configuration.GAMEFIELD_OFFSET.x,
               coordinates.y * Configuration.DISTANCE_FROM_CENTERS_BLOCKS
               + Configuration.GAMEFIELD_OFFSET.y,
               coordinates.z);
        }

        public abstract void ReactionOnClick();
        public abstract UnityEngine.Color GetRGBColor();
        public bool Filled { get; protected set; }
        public Vector3 CoordinateOnBoard
        {
            get
            {
                return coordinateOnBoard;
            }
            set
            {
                coordinateOnBoard = value;
            }
        }
        public GameObject Object { get; set; }

    }
}
