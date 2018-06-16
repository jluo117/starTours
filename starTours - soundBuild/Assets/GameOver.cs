using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameOver : MonoBehaviour {
    private bool end = false;
    private float timeFreeze = 0f;
    private bool videoEnd = false;
    public GameObject wall;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeFreeze += Time.deltaTime;
        long playerCurrentFrame = wall.GetComponent<VideoPlayer>().frame;
        long playerFrameCount = (long)(wall.GetComponent<VideoPlayer>().frameCount - 5);
        if ((playerCurrentFrame >= playerFrameCount) && (!videoEnd))
        {
            videoEnd = true;
            wall.GetComponent<VideoPlayer>().Pause();
            timeFreeze = 0;
            return;
        }
        if ((timeFreeze > 2) && (videoEnd))
        {
            wall.SetActive(false);
            end = true;
            return;
        }
        if ((Input.GetKeyDown(KeyCode.R)) || (OVRInput.GetDown(OVRInput.Button.Start)))
        {
           // Debug.Log("restart");
            Application.LoadLevel("SampleScene");
        }
    }
}
//-585 57 497