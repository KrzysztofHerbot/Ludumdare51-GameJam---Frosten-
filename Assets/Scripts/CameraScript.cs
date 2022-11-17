using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraScript : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                anim.Play("Far");
            }
            else
            {
                anim.Play("Close");
            }
        }
        
    }
}
