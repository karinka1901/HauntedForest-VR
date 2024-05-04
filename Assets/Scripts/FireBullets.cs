using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    private bool inHands = false;

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    void Start()
    {
       // XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.activated.AddListener(Fire);

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        if (triggerValue > 0)
        {
            Fire();
        }
}

public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        spawnedBullet.transform.position = bulletSpawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        Destroy(spawnedBullet, 3f);
    }
}
