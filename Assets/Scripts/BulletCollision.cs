using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.gameObject.tag == "Quit")
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (other.gameObject.tag == "Play")
        {
            SceneManager.LoadScene(1);
            Debug.Log("Play");
        }
        if (other.gameObject.tag == "QuitGame")
        {
            Application.Quit();
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
