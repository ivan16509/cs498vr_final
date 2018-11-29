using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour {

    // Use this for initialization\

    public OVRInput.RawButton button;
    float sinceHit = 4;
    void Start () {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material.color = Color.red;
        lineRenderer.startWidth = .01f;
        lineRenderer.endWidth = .01f;
        lineRenderer.enabled = false;



    }

    // Update is called once per frame
    void Update () {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPositions(new Vector3[] { transform.position, transform.TransformDirection(Vector3.forward) * 100 });
        if (OVRInput.Get(button) && sinceHit > 2)
        {
            lineRenderer.material.color = Color.red;
            lineRenderer.enabled = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward)*100 - transform.position, out hit, 100))
            {
                GravityBox obj = hit.transform.gameObject.GetComponent<GravityBox>();
                if (obj)
                {
                    obj.InvertGravity();
                    sinceHit = 0;

                }
            }


        }
        else
        {
            sinceHit += Time.deltaTime;
            lineRenderer.enabled = false;
        }

    }
}
