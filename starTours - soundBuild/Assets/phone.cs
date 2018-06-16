using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour {
    private bool armed = false;
    private float Launch = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if (this.GetComponent<OVRGrabbable>().isGrabbed)
        {
            armed = true;
        }
        if (!(this.GetComponent<OVRGrabbable>().isGrabbed) && (armed))
        {
            Launch += Time.deltaTime;
            if (Launch > 1)
            {
                Application.LoadLevel("End");
            }
        }
	}
}
