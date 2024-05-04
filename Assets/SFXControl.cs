using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXControl : MonoBehaviour
{
    // Start is called before the first fram
    //
    // e update


    public AudioClip gun;
    public AudioClip enemy;

    public bool isSFXPlaying = false;
    public AudioSource SFXSource;


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (SFXSource == gun)
        {
            SFXSource.volume = 0.23f;
        }
        //if (SFXSource == enemy)
        //{
        //    SFXSource.volume = 1f;
        //    Debug.Log("Enemy SFX");
        //}
    }
    //public void StopSFX()
    //{
    //    //SFXSource.Stop();
    //    //Destroy(gameObject);
    //    isSFXPlaying = false;
    //}

    public void PlaySFX(AudioClip clip)
    {
        //  if (clip != null && SFXSource != null)
        SFXSource.enabled = true;
        isSFXPlaying = true;
            SFXSource.clip = clip;
            SFXSource.Play();
            Debug.Log("Playing SFX: " + clip.name);

        


    }
}


