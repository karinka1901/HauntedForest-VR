using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayersHealth : MonoBehaviour
{
    public int health;
    public bool isDead;
    public bool isHit;
    public int enemyHit;

    public SFXControl sfxControl;

    // FROM CANVAS
    public GameObject deathStuff;
    public HealthBar healthBar;

    public Text enemyKilled;
    void Start()
    {
        isDead = false;
        //USUALLy 100, 20 FOR DEBUGGING
        health = 0;
        deathStuff.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 5)
        {
            isDead = true;
            Debug.Log("Player is dead");
            //Destroy(this.gameObject);
        }
        
        if (isDead)
        {
            deathStuff.SetActive(true);
            enemyKilled.text = "Enemies Killed: " + enemyHit;
            
            // FOR DEBUGGING PURPOSES
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadLevel();
            }
        }
    }

    // USED IN CANVAS BUTTON (DEATH STUFF)
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //sfxControl.SFXSource.enabled = true;
            //sfxControl.SFXSource.PlayOneShot(sfxControl.enemy);
    
           // sfxControl.PlaySFX(sfxControl.enemy);
            health += 1;
            Debug.Log("Player is hit " + health);
           healthBar.UpdateHealth(health);


            
        }
    }
}
