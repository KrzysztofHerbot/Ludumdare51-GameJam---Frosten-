using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class StartLevel : MonoBehaviour
{
    SlotClass[] PriorityList;
    SlotClass[] PriorityList2;
    [SerializeField]GameObject menu;
    [SerializeField]GameObject backButton;
    [SerializeField]TextMeshProUGUI timer;
    [SerializeField]PlayerFreeze playerFreeze;
    MusicThingy musicThingy;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    void Start()
    {
        musicThingy = FindObjectOfType<MusicThingy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void startTheLevel()
    {
        musicThingy.StopPlayingMusic();
        musicThingy.StartPlayingMusic();
        PriorityList = FindObjectsOfType<SlotClass>();
       // PriorityList2 = PriorityList;
        //PriorityList = sortSlots(PriorityList2);
        playerFreeze.FillTheList(PriorityList);
        Time.timeScale = 1;
        timer.enabled = true;
        menu.SetActive(false);
       // FindObjectOfType<PlayerFreeze>().StartOver();

    }

    public void ShowMap()
    {
        menu.SetActive(false);
        backButton.SetActive(true);
        GameObject cameraBlend = GameObject.FindGameObjectWithTag("CameraStates");
        cameraBlend.GetComponent<Animator>().Play("Far");
    }

    public void GoBack()
    {
        GameObject cameraBlend = GameObject.FindGameObjectWithTag("CameraStates");
        cameraBlend.GetComponent<Animator>().Play("Close");
        menu.SetActive(true);
        backButton.SetActive(false);
    }

    SlotClass[] sortSlots(SlotClass[] list)
    {
        int temp = 0;
        for(int i = 0; i < list.Length; i++)
        {
            for (int j = 0; j < list.Length-1; j++)
            {
                if (list[j].orderNumber > list[j + 1].orderNumber)
                {
                    temp = list[j + 1].orderNumber;
                    list[j + 1].orderNumber = list[j].orderNumber;
                    list[j].orderNumber = temp;
                }
            }
        }


        return list;
    }


}
