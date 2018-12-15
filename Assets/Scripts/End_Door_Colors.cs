using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Door_Colors : MonoBehaviour {
    public Light light;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value > 0.9) //a random chance
        {
            light.intensity = Random.Range(0.3f, 1f); // makes the door flicker
        }

    }
}
