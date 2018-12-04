using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayer : GravityBox
{

    // Use this for initialization
    bool switching = false;
    bool beforeRot = false;
    Texture2D blk;
    public bool fade = false;
    public float alph;
    public Camera cam;

    void Start()
    {
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 0));
        blk.Apply();

       
    }

    // Update is called once per frame      

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            InvertGravity();
        }
        if (gravOn)
            gameObject.GetComponent<Rigidbody>().velocity += grav * Time.deltaTime;

        if (!switching)
        {
            Vector3 dir = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            GameObject[] objs = GameObject.FindGameObjectsWithTag("MainCamera");

            Camera cam = objs[0].GetComponent<Camera>();

            Vector3 t = new Vector3(dir.x / 25f, 0,  dir.y / 25f);

            gameObject.transform.Translate(t);


            Vector3 rot = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            gameObject.transform.Rotate(new Vector3(0, rot.x / 5f, 0));



        }
        else
        {
            if (alph == 1f && beforeRot)
            {
                beforeRot = false;
                transform.Rotate(0, 0, 180);
                fade = !fade;
            }
            if (!beforeRot)
            {
                gameObject.transform.Translate(Vector3.down / 50);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.0f))
                {
                    base.InvertGravity();
                    SetGravON();
                    switching = false;

                }
            }
           
            
        }


        if (!fade)
        {
            if (alph > 0)
            {
                alph -= Time.deltaTime * .2f;
                if (alph < 0) { alph = 0f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }
        if (fade)
        {
            if (alph < 1)
            {
                alph += Time.deltaTime * .2f;
                if (alph > 1) { alph = 1f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }



    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    public override void InvertGravity()
    {
        fade = true;
        SetGravOff();
        switching = true;
        beforeRot = true;
    }



}
