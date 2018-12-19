using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private float initial_position;
    private float max_position;

    public SimpleGrabber Left;
    public SimpleGrabber Right;

    private SimpleGrabber Curr = null;
    private float prev_y;

    public GravityPlayer2 Player;

    bool grabbing = false;

    bool isLow = true;

    public AudioSource leverAudioSrc; 

    // Use this for initialization
    void Start () {

        initial_position = transform.position.y;
        max_position = initial_position + .214f * 2;
        leverAudioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update() {
        // Performing a grab

        if (Input.GetKeyDown(KeyCode.A))
        {
            leverAudioSrc.Play(); 
        }
        GrabCheck();
        // Grabbing an object
        if (Curr != null)
        {
            UpdateGrabbing();
            leverAudioSrc.Play(); 
        }


        // Extra Settings!
        if (transform.position.y > max_position)
        {
            transform.position = new Vector3(transform.position.x, max_position, transform.position.z);
        }
        if (transform.position.y < initial_position)
        {
            transform.position = new Vector3(transform.position.x, initial_position, transform.position.z);

        }
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    // check if there is grab, update object info
    void GrabCheck()
    {
        if (Curr == null)
        {
            if ( !Left.IsGrabbing() && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0
            && (Left.transform.position - transform.position).magnitude < .8f)
            {

              
                Curr = Left;
                prev_y = Curr.transform.position.y;
                Curr.SetGrabbing(true);

            }
            else if ( !Right.IsGrabbing() && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0
                && (Right.transform.position - transform.position).magnitude < .8f)
            {
                Curr = Right;
                prev_y = Curr.transform.position.y;
                Curr.SetGrabbing(true);

            }
        }
    }



    // What to perform when grabbing
    void UpdateGrabbing()
    {
        if (!(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0) && Curr == Left)
        {
            LetGo();
        }
        else if (!(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0) && Curr == Right)
        {
            LetGo();
        }
        else
        {
            float diff = Curr.transform.position.y - prev_y;
            transform.Translate(new Vector3(0, diff, 0));
            prev_y = Curr.transform.position.y;
        }
    }

    // What to do when letting go
    void LetGo()
    {
        // MUST DO
        Curr.SetGrabbing(false);
        Curr = null;

        // ACTION
        float distFromStart = Mathf.Abs(transform.position.y - initial_position);
        float distFromMax = Mathf.Abs(transform.position.y - max_position);

        if (distFromStart < distFromMax)
        {
            transform.position = new Vector3(transform.position.x, initial_position, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x, max_position, transform.position.z);
        }

        if (transform.position.y == max_position && isLow || transform.position.y == initial_position && !isLow)
        {            
            Player.InvertGravity();
            isLow = !isLow;
        }

    }

    
}
