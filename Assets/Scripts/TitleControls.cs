using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour
{
    [SerializeField]GameObject mainMenu;
    [SerializeField]GameObject levelSelect;
    [SerializeField]AudioClip menuTheme;
    float currentTime;
    AudioSource ac;
    //MusicThingy musicThingy;
    void Start()
    {
       // musicThingy = FindObjectOfType<MusicThingy>();
        currentTime = 0f;
        ac = GetComponent<AudioSource>();
       // musicThingy.StartPlayingMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ac.isPlaying)
        {
            ac.PlayOneShot(menuTheme);
        }
        currentTime = currentTime + Time.deltaTime;
        if (currentTime >= 20f)
        {
            
            //musicThingy.StartPlayingMusic();
            currentTime = 0;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadFirstLevel()
    {
       // musicThingy.StopPlayingMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void LoadLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void LoadSelectedLevel(int level)
    {
       // musicThingy.StopPlayingMusic();
        SceneManager.LoadScene(level);
    }

}
