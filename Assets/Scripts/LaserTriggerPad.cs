using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerPad : MonoBehaviour {

    public GameObject[] doors;

    float door_y, button_y, initial_door_y, initial_button_y;
    Vector3 startPos, endPos;

    Vector3[] startPositions, endPositions;


    float prevHit = 0f;
    public bool IsOn = false;

    // Use this for initialization
    void Start()
    {

        startPositions = new Vector3[doors.Length];
        endPositions = new Vector3[doors.Length];

        for (int i = 0; i < doors.Length; i++)
        {
            startPositions[i] = doors[i].transform.position;
            endPositions[i] = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y + 4, doors[i].transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (doors != null)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (IsOn)
                {
                    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, endPositions[i], 2*Time.deltaTime);
                }
                else
                {
                    doors[i].transform.position = Vector3.MoveTowards(doors[i].transform.position, startPositions[i], 2*Time.deltaTime);
                }
            }
        }

        if (IsOn && prevHit < Time.time - 2* Time.deltaTime)
        {
            IsOn = false;
        }


    }

    public void Hit()
    {
        prevHit = Time.time;
        IsOn = true;
    }

}
