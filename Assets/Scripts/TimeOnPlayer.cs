using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOnPlayer : MonoBehaviour
{
    [SerializeField] PlayerFreeze playerFreeze;
    [SerializeField] float timePop;
    // Update is called once per frame
    void Update()
    {
        if(playerFreeze.CurrentRunTime < timePop)
        {
            GetComponent<Image>().enabled = false;
        }
        else GetComponent<Image>().enabled = true;
    }
}
