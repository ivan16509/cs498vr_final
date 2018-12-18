using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1_Controller : MonoBehaviour {

    private float startTime = -1f;
    private float holdTime = 3f;

    public string scenename;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        {
            if (startTime < 0)
            {
                startTime = Time.time;
            }
            if (startTime + holdTime <= Time.time)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        else
        {
            startTime = -1f;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.name == "Player")
        {
            SceneManager.LoadScene(scenename);
        }

    }
    
}
