using UnityEngine;

namespace Assets.Scripts
{
    public class Goal
    {
        public Goal(Color color, Vector3 position)
        {
            Color = color;
            Position = position;
        }
        public UnityEngine.Color GetRGBColor()
        {
            switch (Color)
            {
                case Color.Green: return new UnityEngine.Color(0, 255, 0);
                case Color.Yellow: return new UnityEngine.Color(255, 255, 0);
                case Color.Red: return new UnityEngine.Color(255, 0, 0);
                default: return new UnityEngine.Color();
            }
        }
        public Color Color { get; set; }
        public Vector3 Position { get; set; }
        public GameObject Object { get; set; }
    }
}
