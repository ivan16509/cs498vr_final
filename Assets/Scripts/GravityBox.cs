using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBox : MonoBehaviour {

    // Use this for initialization
    protected Vector3 grav = new Vector3(0f, -9.8f, 0f);
    protected bool gravOn = true;
	void Start () {
		
	}
	
	// Update is called once per frame      
	void Update () {
        if (gravOn)
        {
            gameObject.GetComponent<Rigidbody>().velocity += grav * Time.deltaTime;

        }
        if (Input.GetKeyDown("space"))
        {
            this.InvertGravity();
        }
        if (Input.GetKeyDown("a"))
        {
            this.SetGravity(new Vector3(-1, 0, 0));
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
