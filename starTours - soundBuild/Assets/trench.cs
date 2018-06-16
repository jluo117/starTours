using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trench : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0)
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < 0)
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
        if ((Input.GetKey("right")) || ((OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -.2)))
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);
        }
        if ((Input.GetKey("left")) || ((OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > .2)))
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime);
        }
    }
}
