using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpWallScript : MonoBehaviour {
    public enum WallTargetType { None, Red, Blue};
    public WallTargetType wallMissileColorNeeded = WallTargetType.None;
    public GameObject wallToBlowUp;
    private Vector3 startPos = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("colliding");
        if (checkIfMissile(other.tag) || 
            checkIfRedMissile(other.tag) || checkIfBlueMissile(other.tag))
        {
            Debug.Log("hit");
            foreach (Transform child in wallToBlowUp.transform)
            {
                if (child.tag == "obstacleRunway")
                {
                    child.GetComponent<Collider>().enabled = false;
                }
            }
            wallToBlowUp.transform.Translate(500, 0, 0);
            Destroy(wallToBlowUp);
        }
    }

    bool checkIfMissile(string otherTag)
    {
        return wallMissileColorNeeded == WallTargetType.None 
            && (otherTag == "redMissile" || otherTag == "blueMissile");
    }

    bool checkIfRedMissile(string otherTag)
    {

        return wallMissileColorNeeded == WallTargetType.Red
            && (otherTag == "redMissile");
    }

    bool checkIfBlueMissile(string otherTag)
    {
        return wallMissileColorNeeded == WallTargetType.Blue
            && (otherTag == "blueMissile");
    }
}
