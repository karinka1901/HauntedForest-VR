using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;

    public Animator handAnimator;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    private bool isFiring = false;

    public SFXControl sfxControl;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);


        if (triggerValue > 0 && !isFiring)  // Check if trigger is pressed and not already firing
        {
            isFiring = true;  // Set flag to true to prevent multiple firings
            sfxControl.PlaySFX(sfxControl.gun);
            Fire();
        }

        if (triggerValue <= 0)
        {
            isFiring = false;  // Reset flag when trigger is released
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
