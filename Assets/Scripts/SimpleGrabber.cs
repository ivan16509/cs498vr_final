using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabber : MonoBehaviour {

    private bool isGrabbing = false;
    public OVRInput.RawButton[] grabButtons;
    public OVRInput.Controller Controller;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
    public void SetGrabbing (bool g)
    {
        isGrabbing = g;
    }

    public bool IsPressed()
    {
        
        foreach (OVRInput.RawButton b in grabButtons)
        {
            if (!OVRInput.Get(b))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsGrabbing()
    {
        return isGrabbing;
    }
}
