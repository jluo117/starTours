using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour {
    private bool missileFire = false;
	// Use this for initialization
	void Start () {
		if (OVRInput.Get(OVRInput.Button.One))
        {
            if (missileFire)
            {
                Application.LoadLevel("End");
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("colliding");
        if (other.tag == "ObstacleRunway")
        {
            Debug.Log("colliding");
            GameOver();
        }
        if (other.tag == "target")
        {
            Debug.Log("missle ready");
            missileFire = true;
        }
    }
    void GameOver()
    {
        Debug.Log("GameOver");
        this.transform.position = new Vector3(0, 0, 0);
        Application.LoadLevel("GameOver");
    }
}
