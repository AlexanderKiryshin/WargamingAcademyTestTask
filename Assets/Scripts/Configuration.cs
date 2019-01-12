using UnityEngine;

namespace Assets.Scripts
{
    public class Configuration
    {
        public const float DISTANCE_FROM_CENTERS_BLOCKS = 0.6f;
        public const float DISTANCE_ARROW_FROM_CENTR_BLOCK = 0.25f;
        public static readonly Vector2 GAMEFIELD_OFFSET = new Vector2(0, -0.2f);
        public static readonly Vector2 GOAL_OFFSET = new Vector2(0, 0.06f);
        public const float GOAL_DIAMETER = 0.4f;
    }
}
