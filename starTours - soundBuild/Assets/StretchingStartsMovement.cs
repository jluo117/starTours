using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingStartsMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	
	}

    public void Update()
    {
        transform.Translate(-Vector3.forward * 0.005f);
    }
}
