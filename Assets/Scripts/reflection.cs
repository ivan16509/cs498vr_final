using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void drawLin(Vector3 position, Vector3 direction, int originNum, int endingNum)
    {
        if (endingNum > linr.positionCount)
        {
            linr.positionCount += 1;
        }
        linr.SetPosition(originNum, position);
        linr.SetPosition(endingNum, position + direction);
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
            //Debug.Log(i);
            //Debug.Log((Vector3)list[i]);
            //Debug.Log(linr.GetPosition(i + 1));
        }
        //Debug.Log("post");
        //for (int i = 0; i < linr.positionCount; i++)
        //{
        //    Debug.Log(linr.GetPosition(i));
        //}
    }
    void reflect(Vector3 pos, Vector3 dir, int nRef, ArrayList positions)
    {
        if (nRef == 0)
        {
            return;
        }
        //Vector3 start = pos;
        RaycastHit hit;
        Ray ray = new Ray(pos, dir);
        if (Physics.Raycast(ray, out hit, dis))
        {
            //Debug.Log("hit");
            pos = hit.point;
            positions.Add(pos);
            if (hit.collider.gameObject.tag == "greenMirror")
            {
                //Debug.Log("Green");
                dir = Vector3.Reflect(dir, hit.normal);
                //positions.Add(pos);
            }
        }
        else
        {
            //Debug.Log("noHit");
            positions.Add(ray.GetPoint(dis));
        }
        //Debug.Log(positions.Count);
        //Debug.Log("pre");
        reflect(pos, dir, nRef - 1, positions);


    }
    // Update is called once per frame
    void Update()
    {
        //linr.SetPosition(0, transform.position);
        int nRef = 5;
        ArrayList positions = new ArrayList();
        positions.Add(transform.position);
        reflect(transform.position, transform.forward, nRef, positions);
        drawLines(positions);
        Debug.Log("Pos");
        foreach (Vector3 i in positions)
        {
            Debug.Log(i);
        }
        Debug.Log("lineR");
        for (int i = 0; i < linr.positionCount; i++)
        {
            Debug.Log(linr.GetPosition(i));
        }

    }
}
