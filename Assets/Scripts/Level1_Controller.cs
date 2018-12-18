using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1_Controller : MonoBehaviour {


    public string scenename;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("wtf");
        if (collider.gameObject.name == "Player")
        {
            SceneManager.LoadScene(scenename);
        }

    }
    
}
