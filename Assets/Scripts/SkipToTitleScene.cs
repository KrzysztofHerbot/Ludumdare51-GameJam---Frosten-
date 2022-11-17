using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipToTitleScene : MonoBehaviour
{

 
    void LateUpdate()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
