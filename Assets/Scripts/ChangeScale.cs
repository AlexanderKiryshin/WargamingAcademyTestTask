using UnityEngine;
namespace Assets.Scripts
{
    public class ChangeScale : MonoBehaviour
    {
        public int spriteWidth;
        public int spriteHeight;
        public float widthproc = 1;
        public float heightproc = 1;
        public bool bStandart = true;
        public Camera myCamera;
        private int screenWidth = Screen.width;
        private int screenHeight = Screen.height;
        private float scaleX;
        private float scaleY;
        Vector3 vector;
        float width;
        float height;
        float maxIntervalX;
        float correction;
        void Awake()
        {
            correction = (float)screenWidth / (float)spriteWidth;
            if (bStandart)
            {
                scaleX = transform.localScale.x * correction * (float)screenWidth / (float)screenHeight;
                scaleY = transform.localScale.x * correction * (float)screenWidth / (float)screenHeight;
            }
            else
            {
                scaleX = transform.localScale.x * correction * (float)screenWidth / (float)screenHeight * widthproc;
                scaleY = transform.localScale.x * correction * (float)screenWidth / (float)screenHeight / (Camera.main.aspect) * heightproc;
            }
        }
        public void ScaleChange(float widthProc, float heightProc, GameObject gameObjectScaleChange)
        {
            correction = (float)screenWidth / (float)screenHeight / (0.6f / 100f) / 100;
            scaleX = gameObjectScaleChange.transform.localScale.x * correction * widthProc;
            scaleY = gameObjectScaleChange.transform.localScale.x * correction / (Camera.main.aspect) * heightProc;
            gameObjectScaleChange.transform.localScale = new Vector3(scaleX, scaleY);
        }
        public void PositionChange(float widthProc, float heightProc, GameObject gameObjectScaleChange)
        {
            correction = (float)screenWidth / (float)screenHeight / (0.6f / 100f) / 100;
            float posX = gameObjectScaleChange.transform.localScale.x * correction * widthProc;
            float posY = gameObjectScaleChange.transform.localScale.x * correction / (Camera.main.aspect) * heightProc;
            float maxY = 2;
            float maxX = (float)Screen.width / (float)Screen.height * maxY;
            posX = Screen.width;
            posY = Screen.height;
            float test = Camera.main.orthographicSize;
            gameObjectScaleChange.transform.position = new Vector3(maxX * widthProc, maxY * heightProc);
        }
        /* public void ScaleChange(float widthProc, GameObject gameObjectScaleChange)
         {
             correction = (float)screenWidth / (float)screenHeight / (0.6f / 100f) / 100;
             scaleX = gameObjectScaleChange.transform.localScale.x * correction * widthProc;
             scaleY = gameObjectScaleChange.transform.localScale.x * correction* widthProc;
             gameObjectScaleChange.transform.localScale = new Vector3(scaleX, scaleY);
         }*/
        void Update()
        {

        }
        void OnGUI()
        {
        }
    }
}
