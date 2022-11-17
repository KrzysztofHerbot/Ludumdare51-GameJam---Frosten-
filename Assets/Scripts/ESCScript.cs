using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCScript : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject escScreen;
    bool isON;
    MusicThingy musicThingy;
    void Start()
    {
        musicThingy = FindObjectOfType<MusicThingy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && !winScreen.activeInHierarchy && !loseScreen.activeInHierarchy && !startScreen.activeInHierarchy && !isON)
        {
            musicThingy.PauseMusic();
            Time.timeScale = 0;
            isON = true;
            escScreen.SetActive(true);
        }
        else if(Input.GetButtonDown("Cancel") && isON)
        {
            Time.timeScale = 1;
            musicThingy.UnPauseMusic();
            isON = false;
            escScreen.SetActive(false);
        }
    }
}
