using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroy : MonoBehaviour
{
    int currentScene;
    int neo = 0;
    public int Neo { get { return neo; } }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        int numOfMenus = GameObject.FindGameObjectsWithTag("SlotMenu").Length;
        if (numOfMenus <= 1)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            neo = 1;
        }
        else if(currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            Destroy(gameObject);
        }
        else if (currentScene == SceneManager.GetActiveScene().buildIndex)
        {
            DontDestroyOnLoad(gameObject);
            foreach(GameObject menu in GameObject.FindGameObjectsWithTag("SlotMenu"))
            {
                if(menu.GetComponent<DontDestroy>().Neo == 0)
                {
                    Destroy(menu);   //this is some weird programming, if it works lol
                }
            }
        }
    }
}
