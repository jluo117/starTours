using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{

    public float acceleration = 5.0f;
    public float velocity = 20.0f;
    public float lifetime = 8.0f;
    private float initialVelocity = 75f;

    // Use this for initialization
    void Start()
    {
        velocity = initialVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        //timeLeft -= Time.deltaTime;
        velocity += 1;
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Kill();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "ship") || (col.tag == "missile"))
        {
            return;
        }
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
