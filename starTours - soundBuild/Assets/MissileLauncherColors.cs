using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherColors : MonoBehaviour
{
    public GameObject RedMissilePrefab;
    public GameObject BlueMissilePrefab;
    public Transform missileSpawnPoint;
    public float reloadTime = 0.5f;
    public AudioSource fireSound;
    public AudioClip missileFire;
    private float lastFireTime;

    // Use this for initialization
    void Start()
    {
        fireSound.clip = missileFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedFireButtonPressed() && Time.time > lastFireTime + reloadTime)
        {
            GameObject missile = (GameObject)Instantiate(RedMissilePrefab, missileSpawnPoint.position, Quaternion.LookRotation(missileSpawnPoint.forward));
            Physics.IgnoreCollision(GetComponent<Collider>(), missile.GetComponent<Collider>());
            lastFireTime = Time.time;
            fireSound.Play();
        }
        if (isBlueFireButtonPressed() && Time.time > lastFireTime + reloadTime)
        {
            GameObject missile = (GameObject)Instantiate(BlueMissilePrefab, missileSpawnPoint.position, Quaternion.LookRotation(missileSpawnPoint.forward));
            Physics.IgnoreCollision(GetComponent<Collider>(), missile.GetComponent<Collider>());
            lastFireTime = Time.time;
            fireSound.Play();
        }
    }

    bool isRedFireButtonPressed()
    {
        return ((OVRInput.GetDown(OVRInput.Button.One)) || (Input.GetKeyDown("c")));
    }

    bool isBlueFireButtonPressed()
    {
        return ((OVRInput.GetDown(OVRInput.Button.Two)) || (Input.GetKeyDown("v")));
    }
}
