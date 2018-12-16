using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject door;
    public GameObject pad;
    public bool debug;

    public GameObject[] doors;


    float door_y, button_y, initial_door_y, initial_button_y;
    Vector3 startPos, endPos;

    Vector3[] startPositions, endPositions;

    // Use this for initialization
    void Start () {
        initial_button_y = pad.transform.position.y;

        if (door != null)
        {
            startPos = door.transform.position;
            endPos = new Vector3(door.transform.position.x, door.transform.position.y + 4, door.transform.position.z);
        }
        

        if (doors != null)
        {
            startPositions = new Vector3[doors.Length];
            endPositions = new Vector3[doors.Length];

            for (int i = 0; i < doors.Length; i++)
            {
                startPositions[i] = doors[i].transform.position;
                endPositions[i] = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y + 4, doors[i].transform.position.z);
            }
        }
        


    }

    // Update is called once per frame
    void Update () {
        
        if (door != null)
        {
            if (Mathf.Abs(pad.transform.position.y - initial_button_y) > 0.1f)
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, endPos, 2*Time.deltaTime);
            }
            else
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, startPos, 2*Time.deltaTime);
            }
        }

        if (doors != null)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (Mathf.Abs(pad.transform.position.y - initial_button_y) > 0.1f)
                {
                    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, endPositions[i], 2*Time.deltaTime);
                }
                else
                {
                    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, startPositions[i], 2*Time.deltaTime);
                }
            }
        }
        

    }
}
