using UnityEngine;
public class WaitKeybordPress : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Application.Quit();
        }
    }
}
