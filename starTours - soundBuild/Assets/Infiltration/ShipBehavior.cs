using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class exists to handle movement on a 3x3 grid in the XY
 * */
public class ShipBehavior : MonoBehaviour
{
    public GameObject ship;
    public GameObject missle;
    public GameObject ShipLivesText;
    public AudioSource TieSong;
    public float movementSpeedZ = 15.0f;
    private float movementDistanceXYPlane = 0.5f;

    private int curVerticalPosition = 1;
    private int curHorizontalPosition = 1;

    public int maxLimitVertical = 20;
    public int minLimitVertical = 0;
    public int maxLimitHorizontal = 4;
    public int minLimitHorizontal = -1;

    private int shipLifes = 10;

    private Vector3 startPos = new Vector3(0, 0, -20);
    private float endZValue = 1950;
    private bool gameHasBeenBeat = false;
    private float lastLiveLostTime = 0;
    private float timeBetweenHits = 2.0f;

    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        TieSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //  Vector3
        if (!gameHasBeenBeat)
        {
            ZaxisMovement();
        }
        if (this.transform.position.z > endZValue)
        {
            gameHasBeenBeat = true;
            Invoke("switchToVictoryScene", 5.0f);
        }

        VerticalMovementHandler();
        HorizontalMovementHandler();
    }
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("colliding");
        if (other.tag == "ObstacleRunway")
        {
            Debug.Log("colliding");
            if(lastLiveLostTime + timeBetweenHits < Time.time)
            {
                shipLifes--;
                ShipLivesText.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + shipLifes;
                lastLiveLostTime = Time.time;
            }

            GameOver();
        }
        if (other.tag == "turrentBadMissile")
        {
            Debug.Log("missle hit us dummy");
            if (lastLiveLostTime + timeBetweenHits < Time.time)
            {
                shipLifes--;
                ShipLivesText.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + shipLifes;
                lastLiveLostTime = Time.time;
            }

            GameOver();
        }
        if (other.tag == "target")
        {
            Debug.Log("missle ready");
            missle.SetActive(true);
        }
    }

    void GameOver()
    {

        Debug.Log("life: " + shipLifes);

        Debug.Log("GameOver");
        this.transform.position = startPos;
        curVerticalPosition = 1;
        curHorizontalPosition = 1;

        if (shipLifes == 0)
        {
            Application.LoadLevel("GameOver");
        }
    }

    void ZaxisMovement()
    {
        Vector3 position = transform.position;
        position.z += movementSpeedZ * Time.deltaTime;
        this.transform.position = position;
    }

    void VerticalMovementHandler()
    {
        if (shouldMoveUp() && curVerticalPosition < maxLimitVertical)
        {
            this.transform.Translate(Vector3.up * movementDistanceXYPlane);
            curVerticalPosition++;
        }
        else if (shouldMoveDown() && curVerticalPosition > minLimitVertical)
        {
            this.transform.Translate(Vector3.down * movementDistanceXYPlane);
            curVerticalPosition--;
        }
    }

    void HorizontalMovementHandler()
    {
        if (shouldMoveRight() && curHorizontalPosition < maxLimitHorizontal)
        {
            this.transform.Translate(Vector3.right * movementDistanceXYPlane);
            curHorizontalPosition++;
        }
        else if (shouldMoveLeft() && curHorizontalPosition > minLimitHorizontal)
        {
            this.transform.Translate(Vector3.left * movementDistanceXYPlane);
            curHorizontalPosition--;
        }
    }

    private void switchToVictoryScene()
    {
        Application.LoadLevel("End");
    }

    private bool shouldMoveLeft()
    {
        return ((Input.GetKey("left")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -.4));
    }

    private bool shouldMoveRight()
    {
        return ((Input.GetKey("right")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > .4));
    }

    private bool shouldMoveUp()
    {
        return ((Input.GetKey("up")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > .4));
    }
    private bool shouldMoveDown()
    {
        return ((Input.GetKey("down")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < -.4));
    }
}
//300 fire missile ready