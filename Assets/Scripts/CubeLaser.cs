using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLaser : MonoBehaviour {

    public GameObject door;
    public LineRenderer linr;

    // Use this for initialization
    float door_y, button_y, initial_door_y, initial_button_y;
    Vector3 startPos, endPos;
  
    void Start () {
        startPos = door.transform.position;
        endPos = new Vector3(door.transform.position.x, door.transform.position.y + 4, door.transform.position.z);
    }

    // Update is called once per frame
    void Update () {
        linr.SetPosition(0, transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            if (hit.collider)
            {
                linr.SetPosition(1, hit.point);
                Debug.Log(hit.collider.tag);
            }
        }

        // start
        if (hit.collider.gameObject.tag == "greenMirror")
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPos, Time.deltaTime);
        }
        else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, startPos, Time.deltaTime);
        }
    }
}
