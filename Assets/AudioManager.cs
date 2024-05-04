
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] public AudioSource musicSource;
    //[SerializeField] AudioSource SFXSource;


    [Header("Background Music")]
    public AudioClip menuBackground;
    public AudioClip gameBackground;






    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //   musicSource.volume = 0.5f;

    }



    private void Update()
    {

        //Debug.Log("Music Source: " + musicSource);

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (musicSource.clip != menuBackground)
            {
                // musicSource.Stop();
                musicSource.clip = menuBackground;
                musicSource.Play();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (musicSource.clip != gameBackground)
            {
                //  musicSource.Stop();    
                musicSource.clip = gameBackground;
                musicSource.Play();
            }

        }

    }


    public void StopMusic()
    {
        musicSource.Stop();

    }



}
