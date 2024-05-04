using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    public PLayersHealth player;
    public bool startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        player = FindObjectOfType<PLayersHealth>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
 

        if (other.gameObject.tag == "Play")
        {
            player.gameON = true;
            player.rules.SetActive(false);
            player.gameMenu.SetActive(false);
            Debug.Log("Game Started");
        }
        if (other.gameObject.tag == "QuitGame")
        {
            Application.Quit();
        }

        if(other.gameObject.tag == "Quit")
        {
            player.gameMenu.SetActive(false);
            player.rules.SetActive(true);
            Debug.Log("Rules");
        }

        if (other.gameObject.tag == "Treasure")
        {
            player.isCollected = true;
            Destroy(other.gameObject);
            Debug.Log("Treasure Collected");
        }

        //Button button = other.GetComponent<Button>();

        //if (button != null)
        //{
        //    // Simulate a button click
        //    button.onClick.Invoke();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

}
