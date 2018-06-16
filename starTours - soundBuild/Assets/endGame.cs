using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class endGame : MonoBehaviour {
    public GameObject wall;
    public AudioClip outputSound;
    public AudioSource userSound;
    private bool end = false;
   // public GameObject video;
	// Use this for initialization
	void Start () {
        userSound.clip = outputSound;
	}
	
	// Update is called once per frame
	void Update () {
        long playerCurrentFrame = wall.GetComponent<VideoPlayer>().frame;
        long playerFrameCount = (long)(wall.GetComponent<VideoPlayer>().frameCount);
        if (playerCurrentFrame >= playerFrameCount)
        {
            wall.SetActive(false);
            userSound.Play();
            end = true;
        }
        if ((Input.GetKeyDown(KeyCode.R)) || (OVRInput.GetDown(OVRInput.Button.Start)))
        {
            Application.LoadLevel("SampleScene");
        }
	}
}
