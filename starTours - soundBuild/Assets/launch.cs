using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour {
    public GameObject hyperJump;
    public GameObject deathStar;
    public float gameTime = 0.0f;
    public float speed = 0f;
    private bool jump = false;
    private bool inRange = false;
    private Quaternion lastRotation = new Quaternion(0, 0, 0, 0);
    public float rotate = 0f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        Quaternion deltaRot = transform.rotation * Quaternion.Inverse(lastRotation);


        if (this.transform.position.y > -110)
        {

            speed += Time.deltaTime * 20;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            return;

        }
        else if (!jump)
        {
            jump = true;
            hyperJump.GetComponent<ParticleSystem>().Play();
            gameTime = (float)0.0;

            return;
        }
        Debug.Log("Before here");

        ParticleSystem ps = hyperJump.GetComponent<ParticleSystem>();
        var main = ps.main;


        Debug.LogError("");
        
        if ((gameTime < 7) && (!inRange))
        {
            //var module = hyperJump.GetComponent<ParticleSystem>().main;
            //module.startSpeed = module.startSpeed.constant * 3 * Time.deltaTime;
            main.startSpeedMultiplier = gameTime;
            Debug.Log("After here");
            return;
            //var shape = particleSystem.shape;
            //shape.radius += -1 * Time.deltaTime;
            // particleSystem.shape = shape;

        }
        else if ((gameTime < 11.8) && (!inRange))
        {
            Debug.Log("Reached Here");
            main.startSpeedMultiplier = 12 - gameTime;
            return;
        }



        if (!inRange)
        {
            hyperJump.GetComponent<ParticleSystem>().Stop();
            Vector3 deathStarPos = this.transform.position;
            deathStarPos.z += 300;
            deathStar.transform.position = deathStarPos;
           // gameObject.AddComponent<FlightContorl>();
            gameTime = 0;
            inRange = true;
            return;
        }
        if ((inRange) && (gameTime < 10.0))
        {
            Vector3 position = transform.position;
            position.z += 10 * Time.deltaTime;
            this.transform.position = position;
            return;
        }
        Application.LoadLevel("InfiltrationScene");
    }
    

}
// -112.28   60
