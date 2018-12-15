using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Mirror : MonoBehaviour {


    public Transform MirrorCam;
    public Transform MirrorHolder;

    public Transform PlayerCam;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CalcRot();
	}

    public void CalcRot()
    {
        Vector3 dir = (PlayerCam.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;
        MirrorCam.localRotation = rot;

        MirrorHolder.localRotation = transform.parent.parent.localRotation;
    }
}
