using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabber : MonoBehaviour {

    public bool IsGrabbing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetGrabbing (bool g)
    {
        IsGrabbing = g;
    }
}
