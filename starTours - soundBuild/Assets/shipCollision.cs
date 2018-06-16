using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipCollision : MonoBehaviour {
    public GameObject missile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding");
        if (other.tag == "ObstacleRunway")
        {
            GameOver();
        }
        if (other.tag == "target")
        {
            Debug.Log("missle ready");
            missile.SetActive(true);
        }
    }
    void GameOver()
    {
        Debug.Log("GameOver");
        this.transform.position = new Vector3(0, 0, 0);
        Application.LoadLevel("GameOver");
    }
}
