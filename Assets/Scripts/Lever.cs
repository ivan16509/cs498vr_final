using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private float initial_position;
    private float max_position;
	// Use this for initialization
	void Start () {
        initial_position = transform.position.y;
        max_position = initial_position + .214f;
    }

    // Update is called once per frame
    void Update () {
        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
        Debug.Log(transform.position.y);
        /*
        if (transform.position.y <= max_position && transform.position.y >= initial_position)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
        */
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
