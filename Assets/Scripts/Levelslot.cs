using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Levelslot : MonoBehaviour
{
    [SerializeField] int levelNumber;
    public int LevelNumber { get { return levelNumber; } }
    void Start()
    {
        foreach(TextMeshProUGUI textPro in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if(textPro.tag == "LevelNumber")
            {
                textPro.text = "LEVEL " + levelNumber.ToString();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
