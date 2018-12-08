using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBox : MonoBehaviour {

    // Use this for initialization
    public Vector3 grav = new Vector3(0f, -9.8f, 0f);
    public bool gravOn = true;
	void Start () {
		
	}
	
	// Update is called once per frame      
	void Update () {
        if (gravOn)
        {
            gameObject.GetComponent<Rigidbody>().velocity += grav * Time.deltaTime;
        }
    }
    public void SetGravity(Vector3 newGrav)
    {
        grav = newGrav;
    }

    public virtual void InvertGravity()
    {
        grav = -grav;
    }
    
    public void SetGravOff()
    {
        gravOn = false;
    }
    public void SetGravON()
    {
        gravOn = true;
    }
}
