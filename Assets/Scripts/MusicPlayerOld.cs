using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerOld : MonoBehaviour
{
    //fields for audio clip storage
    [SerializeField] AudioClip titleMusic;   
    [SerializeField] AudioClip clip1;
    AudioSource soundtrack; 
    bool isPlayingTitleMusic;
    bool isPlayingTrack1Clip1;


     void Awake()
     {

        //Make sure there is only ever one instance of the Music Player

        soundtrack = GetComponent<AudioSource>();
        
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //Keep the music player between scenes
            DontDestroyOnLoad(gameObject);
        }
    }



    void Start()
    {
        //soundtrack = GetComponent<AudioSource>();
    }


  
    void Update()
    {
        //CheckForSceneChange();
        StopMusicBetweenScenes();   //This activates when no longer on the Title Screen
       
    }

    void LateUpdate() 
    {
        PlayTrack1();   //Title Screen music
        PlayTrack2();   //Level Music
    }

    void CheckForSceneChange()
    {

    }

    void StopMusicBetweenScenes()
    {
        StopTitleMusic();  //These only activate if the scene changes and is no longer valid for each track
        StopTrack1Clip1();
    }

    private void StopTitleMusic()
    {
        //If no longer on the Title Screen, stop Title Music
        if (SceneManager.GetActiveScene().name != "TitleScreen" && isPlayingTitleMusic == true)
        {
            soundtrack.Stop();
            isPlayingTitleMusic = false;
        }
    }

    private void StopTrack1Clip1()
    {
        //If no longer on Level 1, stop Music
        if (SceneManager.GetActiveScene().name != "Level1" && isPlayingTrack1Clip1 == true)
        {
            soundtrack.Stop();
            isPlayingTrack1Clip1 = false;
        }
    }


    void PlayTrack1()
    {
        //Starts Track 1 if you're on the title screen
        if(SceneManager.GetActiveScene().name == "TitleScreen")
        {
             if(!soundtrack.isPlaying)
            {
                soundtrack.PlayOneShot(titleMusic);
                isPlayingTitleMusic = true;   //This allows us to know which track is playing later
            }
        }
    }

    void PlayTrack2()
    {
         if(SceneManager.GetActiveScene().name == "MusicTestingLevel")
        {
             if(!soundtrack.isPlaying)
            {
                soundtrack.PlayOneShot(clip1);
            }
        }
    }
}
