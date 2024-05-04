using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60.0f; 
    private float currentTime;
    public PLayersHealth playersHealth;

    public Text timerText; 

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        // Update the current time
        currentTime -= Time.deltaTime;

        if (playersHealth.gameON)
        {
            DisplayTime(currentTime);
        }
        

        if (currentTime <= 0)
        {
            currentTime = 0;
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
