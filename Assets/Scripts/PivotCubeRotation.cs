using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCubeRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
