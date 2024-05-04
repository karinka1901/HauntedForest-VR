using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PLayersHealth playersHealth;
    //public Slider healthSlider;
    //public Image life1;
    //public Image life2;
    //public Image life3;
    //public Image life4;
    //public Image life5;
   // public List<Image> lifeImages = new List<Image>();
    public Image[] images;
    public SFXControl sfxControl;


    // Initialize the health bar
    private void Start()
    {

        foreach (Image life in images)
        {
            life.enabled = true;
        }

        //playersHealth = FindObjectOfType<PLayersHealth>();
        //healthSlider.maxValue = 100;
        ////USUALLY 100, 20 FOR DEBUGGING
        //healthSlider.value = 100;


    }

    private void Update()
    {
        //healthSlider.value = playersHealth.health;

    }

    public void UpdateHealth(int currentHealth)
    {
        // Ensure the currentHealth is within the valid range of the images array
       
        images[currentHealth-1].enabled = false;
        sfxControl.PlaySFX(sfxControl.enemy);

     
 
    }
}

