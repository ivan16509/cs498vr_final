using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class reflection : MonoBehaviour
{

    // Use this for initialization
    private LineRenderer linr;
    public GameObject origin;
    public float dis = 20000f;

    void Start()
    {
        linr = GetComponent<LineRenderer>();
        linr.positionCount = 2;
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
                }
                break;
            }
            
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
