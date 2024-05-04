using JetBrains.Annotations;
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
    public bool gameWon;
    public bool isHit;
    public int enemyHit;

    public SFXControl sfxControl;

    // FROM CANVAS
    public GameObject deathStuff;
    public GameObject wonStuff;
    public HealthBar healthBar;

    public Text enemyKilled;

    public TreasureScript treasure;

    public GameObject nightSky;
    public GameObject daySky;
    public ParticleSystem fog;


    public bool gameON;
    //public bool gameRestarted;

    public GameObject gameMenu;
    public GameObject rules;

    public bool isCollected;
    void Start()
    {
        Application.targetFrameRate = 60;
        fog.Play();
        rules.SetActive(false);
        daySky.SetActive(false);
        gameON = false;
        gameMenu.SetActive(true);
        deathStuff.SetActive(false);
        wonStuff.SetActive(false);

        isDead = false;
        gameWon = false;
        //USUALLy 100, 20 FOR DEBUGGING
        health = 0;
        //deathStuff.SetActive(false);
        //wonStuff.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {
      
        if (isCollected == true)
        {
            gameWon = true;
            gameMenu.SetActive(false);
            wonStuff.SetActive(true);
            Destroy(fog);
            nightSky.SetActive(false);
            daySky.SetActive(true);
        }

        if (health >= 5)
        {
            isDead = true;
            Debug.Log("Player is dead");
            //Destroy(this.gameObject);
        }
        
        if (isDead)
        {
            // deathStuff.SetActive(true);
            gameMenu.SetActive(false);
            deathStuff.SetActive(true);
            enemyKilled.text = "Enemies Killed: " + enemyHit;
            Debug.Log("Player is dead");
            // FOR DEBUGGING PURPOSES
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadLevel();
            }
        }
        if(gameWon)
        {
          //  wonStuff.SetActive(true);
            enemyKilled.text = "Enemies Killed: " + enemyHit;
            
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
