using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneLoad : MonoBehaviour
{
    [SerializeField] int menuSceneIndex;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject deathScreen;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI blocksText;
    PlayerFreeze playerFreeze;
    public void ReloadLevel()
    {
        
       Time.timeScale = 1;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        playerFreeze = FindObjectOfType<PlayerFreeze>();
        Debug.Log("Line 29 of SceneLoad " + gameObject.name);
        timeText.text = "Time: " + playerFreeze.FinishTime.ToString("F2");
        blocksText.text = "Blocks used: " + playerFreeze.FreezeCount;
    }

    public void ReloadLevelAfterDeath()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // deathScreen.SetActive(false);
        // menu.SetActive(true);
        // FindObjectOfType<PlayerFreeze>().StartOver();
    }

    public void NextLevel()
    {
        Debug.Log("It will load next scene - Check comment in the script SceneLoad.cs");
        if(SceneManager.GetActiveScene().buildIndex + 1>SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(menuSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Debug.Log("It will load MainMenu scene - Check comment in the script SceneLoad.cs");
        SceneManager.LoadScene(menuSceneIndex);
    }
}
