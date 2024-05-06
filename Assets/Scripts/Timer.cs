using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60.0f; 
    private float currentTime;
    public PLayersHealth playersHealth;
    public Light directionalLight;

    public Text timerText;

    
    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        // Update the current time
        

        if (playersHealth.gameON && currentTime >= 0)
        {
            DisplayTime(currentTime);
            currentTime -= Time.deltaTime;

         
        }
        else if (currentTime <= 0)
        {
            playersHealth.isDead = true;
        }
        

    }

    void DisplayTime(float timeInSeconds)
    {
       
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);

      
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
