using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThingy : MonoBehaviour
{
    int numberOfSongs;
    [SerializeField] AudioClip[] songs;
    AudioSource ac;
    [SerializeField] int numbersPlayed;
    [SerializeField] int currentNumberSong;
    private void Awake()
    {
        //int numMusicPlayers = FindObjectsOfType<MusicThingy>().Length;
        //if (numMusicPlayers > 1)
        //{
       //     Destroy(gameObject);
       // }
       // else
        //{
            DontDestroyOnLoad(gameObject);
        //}
        
        ac = GetComponent<AudioSource>();
        //songs = new AudioClip[numberOfSongs];
        numberOfSongs = songs.Length;
        numbersPlayed = 0;
    }

    private void Start()
    {
        
    }

    public void StartPlayingMusic()
    {
        if(GetComponent<AudioSource>() == null) { return; }
        if(numberOfSongs == 0) { numberOfSongs = 1; }
        currentNumberSong = numbersPlayed % numberOfSongs;
        ac.PlayOneShot(songs[currentNumberSong]);
        numbersPlayed++;
    }

    public void StopPlayingMusic()
    {
        if (GetComponent<AudioSource>() == null) { return; }
        ac.Stop();
    }

    public void PauseMusic()
    {
        if (GetComponent<AudioSource>() == null) { return; }
        ac.Pause();
    }
    public void UnPauseMusic()
    {
        if (GetComponent<AudioSource>() == null) { return; }
        ac.UnPause();
    }


}
