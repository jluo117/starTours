using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsPlayer : MonoBehaviour {

    public Vector3 seat;
    public bool outBounds = false; // flag for position relative to trench
    public bool hittable = false;
    private float timer = 0f;
    private float timeEnd = 1.25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        seat = this.transform.position;
        AboveTrench();
    }

    public void printHi()
    {
        Debug.Log("Hi");
    }

    public void AboveTrench(){
        Debug.Log("hittable flag: " + hittable);

      
        // if y position is higher than 58
        // player is above the trench
        if (seat.y > 90)
        {
 
            outBounds = true;
        }

        // else they are inside the trench
        else
        {
            //Debug.Log("Inside of trench");
            outBounds = false;
            hittable = false;

            // reset timer
            timer = 0;
            
        }

        // if they player is outside the trench
        // add times in seconds to the timer
        if (outBounds == true)
        {
            timer += Time.deltaTime;
        }

        // if they player has been outside the trench
        // longer than time end they will be shot down
        if (timer > timeEnd)
        {

            hittable = true;

            //Debug.Log(timer);
            Debug.Log("DANGER DANGER");

          
        }
       
    }
}
