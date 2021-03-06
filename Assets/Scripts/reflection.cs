﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class reflection : MonoBehaviour
{

    // Use this for initialization
    private LineRenderer linr;
    public GameObject origin;
    public float dis = 20000f;

    private Color laser_color = Color.red;
    private Color hit_color = Color.green;

    void Start()
    {
        linr = GetComponent<LineRenderer>();
        linr.positionCount = 2;

        linr.GetComponent<Renderer>().material.color = laser_color;
        linr.SetColors(laser_color, laser_color);

        linr.SetWidth(0.14F, 0);

    }
    void drawLines(ArrayList list)
    {
        linr.positionCount = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            if (i > linr.positionCount)
            {
                linr.positionCount += 1;
            }
            linr.SetPosition(i, (Vector3)list[i]);
        }
    }
    void reflect(Vector3 pos, Vector3 dir, ArrayList positions)
    {
        
        //Vector3 start = pos;


        RaycastHit hit;
        Ray ray = new Ray(pos, dir);
        RaycastHit[] hits = Physics.RaycastAll(pos, dir.normalized).OrderBy(h => h.distance).ToArray();

        bool isHitting = false;

        while (hits.GetLength(0) != 0)
        {
            pos = hits[0].point;
            positions.Add(pos);

            // check if obj is mirror
            if (hits[0].collider.gameObject.GetComponent<Mirror>() != null)
            {
                dir = Vector3.Reflect(dir, hits[0].normal);
                hits = Physics.RaycastAll(pos, dir.normalized).OrderBy(h => h.distance).ToArray();
                //positions.Add(pos);
            } else if (hits[0].collider.gameObject.GetComponent<Transparent>() != null)
            {
                int len = hits.Length;
                hits = hits.Skip(1).Take(len-1).ToArray();
            } else
            {
                LaserTriggerPad val = hits[0].collider.gameObject.GetComponent<LaserTriggerPad>();
                if (val)
                {
                    val.Hit();
                    linr.GetComponent<Renderer>().material.color = hit_color;
                    linr.SetColors(hit_color, hit_color);

                    linr.SetWidth(0.14F, 0);
                    isHitting = true;
                }
                break;
            }
            
        }

        if (!isHitting)
        {
            linr.GetComponent<Renderer>().material.color = laser_color;
            linr.SetColors(laser_color, laser_color);

            linr.SetWidth(0.14F, 0);
        }

        // check if only the origin is in the array --> if so make laser point in "dis" direction
        if (positions.Count == 1)
        {
            positions.Add(pos + dir.normalized * dis);
        }

    }
    // Update is called once per frame
    void Update()
    {
        ArrayList positions = new ArrayList();
        positions.Add(transform.position);
        reflect(transform.position, transform.up, positions);

        drawLines(positions);

    }
}
