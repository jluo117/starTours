using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightControler : MonoBehaviour
{
    private float yValueOfEuler = 0f;
    private float xValueOfEuler = 0f;
    private float zValueOfEuler = 0f;
    private bool start = false;
    public float detalRot;
    //public GameObject Plane;
    public GameObject Xwing;
    // public GameObject cube;
    public GameObject missle;
    public float acceleration = 0;
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    private Quaternion lastRotation = new Quaternion(0, 0, 0, 0);
    private string leftKey = "left";
    private string rightKey = "right";
    public List<GameObject> misslesFired;
    private float magnitudeOfAcceleration = 0.5f;
    private int magnitudeOfTurns = 2;

    // Use this for initialization
    void Start()
    {
        //cube.GetComponent<Renderer>().material.color =
        //       new Color(1.0f, 1.0f,1.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            if ((OVRInput.Get(OVRInput.Button.Two)) || (Input.GetKey("p")))
            {
                start = true;
                this.transform.position = new Vector3(102, 825, 931);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            return;
        }

        Vector3 deltaPos = transform.position - lastPosition;
        Quaternion deltaRot = transform.rotation * Quaternion.Inverse(lastRotation);

        bool moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool moveBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool dpad_move = false;

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0)
        {
            moveForward = true;
            dpad_move = true;

        }

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < 0)
        {
            moveBack = true;
            dpad_move = true;
        }



        if (((dpad_move) && (moveForward)) || (Input.GetKey("w")))
        {
            print("up");
            if (acceleration < 100)
            {
                acceleration += magnitudeOfAcceleration;
            }
        }

        if ((dpad_move) && ((moveBack)) || (Input.GetKey("s")))
        {
            print("down");
            if (acceleration > 0)
            {
                acceleration += -magnitudeOfAcceleration;
            }
        }

        if ((Input.GetKey("right")) || ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < -.2)))
        {
            print("left");
            yValueOfEuler -= magnitudeOfTurns;
        }
        if ((Input.GetKey("left")) || ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > .2)))

        {
            print("Right");
            yValueOfEuler -= -magnitudeOfTurns;
        }
        if ((Input.GetKey("down")) || ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y < -.2)))
        {
            xValueOfEuler -= magnitudeOfTurns;
        }
        if ((Input.GetKey("up")) || ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y > .2)))
        {
            xValueOfEuler += magnitudeOfTurns;

        }
        if ((Input.GetKey("a")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -.3))
        {
            zValueOfEuler -= magnitudeOfTurns;
            Vector3 xwingRot = Xwing.transform.eulerAngles;
            xwingRot.z = zValueOfEuler;
            Xwing.transform.rotation = Quaternion.Euler(xwingRot);
        }
        if ((Input.GetKey("d")) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > .3))
        {
            zValueOfEuler += magnitudeOfTurns;
            Vector3 xwingRot = Xwing.transform.eulerAngles;
            xwingRot.z = zValueOfEuler;
            Xwing.transform.rotation = Quaternion.Euler(xwingRot);
        }
        if (acceleration > 0)
        {
            transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

        }
        this.transform.rotation *= deltaRot;
        Vector3 euler = transform.rotation.eulerAngles;
        // Vector3 xwingRot = Xwing.transform.eulerAngles;
        euler.y += yValueOfEuler;
        euler.x += xValueOfEuler;
        //  xwingRot.z = zValueOfEuler;
        transform.rotation = Quaternion.Euler(euler);
        // Xwing.transform.rotation = Quaternion.Euler(xwingRot);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            this.transform.position = new Vector3(0, 0, 50);
        }
    }
}
