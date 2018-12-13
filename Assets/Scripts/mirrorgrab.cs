using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorgrab : MonoBehaviour {


    private SimpleGrabber Curr = null;
    private float prev_y;

    private Quaternion initHandRot;
    private Quaternion initMirrorRot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Curr != null)
        {
            if (!Curr.IsPressed())
            {
                LetGo();
            }
            else
            {
                WhileGrabbing();
            }
        }
        */
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        SimpleGrabber g = other.GetComponent<SimpleGrabber>();
        if (g != null && Curr == null && !g.IsGrabbing() && g.IsPressed())
        {
            g.SetGrabbing(true);
            Curr = g;
            initHandRot = OVRInput.GetLocalControllerRotation(Curr.Controller);
            initMirrorRot = transform.parent.parent.localRotation;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        
    }



    void WhileGrabbing()
    {
        //Quaternion diff = Quaternion.Inverse(initHandRot) * OVRInput.GetLocalControllerRotation(Curr.Controller);

        //transform.parent.parent.localRotation = diff * initMirrorRot;
        transform.parent.parent.position = Curr.transform.position + Curr.transform.forward;
        //transform.parent.parent.rotation = Quaternion.Inverse(Curr.transform.rotation);
    }


    void LetGo()
    {
        // MUST DO
        Curr.SetGrabbing(false);
        Curr = null;

        // ACTION
        
    }
    */

}
