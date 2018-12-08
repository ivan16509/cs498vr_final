using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmRotation : MonoBehaviour {

    public GravityPlayer2 player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
        //transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        /*
        if (transform.GetComponent<Rigidbody>().angularVelocity.magnitude > 6)
        {
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            player.InvertGravity();
        }
        */
    }
}