using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public float reloadTime = 2f;
    public AudioSource fireSound;
    public AudioClip missileFire;
    public bool isAITurrent = false;

    private float lastFireTime;

    // Use this for initialization
    void Start()
    {
        fireSound.clip = missileFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireButtonPressed() && Time.time > lastFireTime + reloadTime && !isAITurrent)
        {
            fireMissile();
        }
    }

    bool isFireButtonPressed()
    {
        return ((OVRInput.GetDown(OVRInput.Button.One)) || (Input.GetKeyDown("c")));
    }

    public void fireMissile()
    {
        GameObject missile = (GameObject)Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.LookRotation(missileSpawnPoint.forward));
        Physics.IgnoreCollision(GetComponent<Collider>(), missile.GetComponent<Collider>());
        lastFireTime = Time.time;
        fireSound.Play();
    }
}
