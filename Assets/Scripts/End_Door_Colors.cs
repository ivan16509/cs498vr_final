using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Door_Colors : MonoBehaviour {
    public Light light;
    public Material static_effect;
    private float scrollSpeed = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
         float offset = Time.time * scrollSpeed;

        if (Random.value > 0.95) //a random chance
        {
            light.intensity = Random.Range(0.3f, 1f); // makes the door flicker
            static_effect.mainTextureScale = new Vector2(Random.Range(2f, 5f), Random.Range(2f, 5f));
        }
        //float scaleX = Mathf.Cos(Time.time) * .7f + 1;
        //float scaleY = Mathf.Sin(Time.time) * .7f + 1;
        //static_effect.mainTextureScale = new Vector2(scaleX, scaleY);

    }
}
