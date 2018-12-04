using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject door;
    public GameObject pad;
    public bool debug;

    float door_y, button_y, initial_door_y, initial_button_y;
    Vector3 startPos, endPos;
    bool pressed = false;
    // Use this for initialization
    void Start () {
        initial_button_y = pad.transform.position.y;
        startPos = door.transform.position;
        endPos = new Vector3(door.transform.position.x, door.transform.position.y + 4, door.transform.position.z);


    }

    // Update is called once per frame
    void Update () {
        
        if (Mathf.Abs(pad.transform.position.y - initial_button_y) > 0.1f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPos, Time.deltaTime);
        } else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, startPos, Time.deltaTime);
        }
    }
}
