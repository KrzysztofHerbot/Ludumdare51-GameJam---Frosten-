using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerFreeze : MonoBehaviour
{
    float currentRunTime;
    public float CurrentRunTime {get {return currentRunTime; } }
    float startRunTime;

    float normalSpeed;
    [Tooltip("Multiplayer of speed in first 2 seconds")][SerializeField] float speedIncrease = 2f;

    [SerializeField]TextMeshProUGUI timeText;
    [SerializeField]GameObject deathScreen;
    [SerializeField]GameObject winScreen;
    [SerializeField]float coyoteKillTime = 0.05f;
   // [SerializeField]GameObject cinemaCamera;

    int freezeCount;
    float lockTransformZ;
    bool isOnKillTrigger;
    public int FreezeCount { get { return freezeCount; } }
    float finishTime;
    public float FinishTime { get { return finishTime; } }

    [Header("Block prefab types")]
    //[SerializeField] GameObject playerBlock;
    [SerializeField] GameObject squareBlock;
    [SerializeField] GameObject longBlock;
    [SerializeField] GameObject jumpBlock;
    [SerializeField] GameObject horizontalBlock;
    [SerializeField] GameObject verticalBlock;
    [Header("Transparent block types")]
    [SerializeField] GameObject squareCube;
    [SerializeField] GameObject longCube;
    [SerializeField] GameObject jumpCube;
    [SerializeField] GameObject horizontalCube;
    [SerializeField] GameObject verticalCube;
    [Header("Sound effects")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip freezeSFX;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip checkpointSFX;
    [SerializeField] AudioClip deathSong;

    [SerializeField] List<GameObject> blocksToUse = new List<GameObject>();
    CharacterMove25D characterMove;
    AudioSource ac;
    MusicThingy musicThingy;
    void Start()
    {
        ac = GetComponent<AudioSource>();
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
        characterMove = GetComponent<CharacterMove25D>();
        normalSpeed = characterMove.playerSpeed;
        characterMove.playerSpeed = speedIncrease * characterMove.playerSpeed; // Increase speed in first 2 seconds
        blocksToUse.Clear();
        lockTransformZ = transform.position.z;
        musicThingy = FindObjectOfType<MusicThingy>();
        
        //StartOver();
        /*
        blocksToUse.Add(jumpBlock);
        blocksToUse.Add(horizontalBlock);
        blocksToUse.Add(verticalBlock);
        blocksToUse.Add(squareBlock);
        blocksToUse.Add(longBlock);
        SetBlock();*/
    }

    private void OnEnable()
    {
        isOnKillTrigger = false;
        startRunTime = 10f;
        finishTime = 0f;
        freezeCount = 0;
        currentRunTime = startRunTime;
        lockTransformZ = transform.position.z;
        //StartOver();
    }

    void Update()
    {
        ProcessLockZPosition();
        finishTime = finishTime + Time.deltaTime;
        if(currentRunTime <8f)
        {
            characterMove.playerSpeed = normalSpeed;
        }
        
        timeText.text = currentRunTime.ToString();
        currentRunTime = currentRunTime - Time.deltaTime;
        if(currentRunTime <= 0f)
        {
            // = loopCount + 1;
            Freeze();
        }
        /*if (Input.GetKeyDown(KeyCode.R))  //Debug option, delete when publishing
        {
            //loopCount = loopCount + 1;
            Freeze();
        }*/
        if (Input.GetKeyDown(KeyCode.R))  //Restarts level
        {
            blocksToUse.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Q))  //Zooms out to see map
        {
            //cinemaCamera.GetComponent<CinemachineVirtualCamera>().
        }
    }

    void ProcessLockZPosition()
    {
        if (Mathf.Abs(gameObject.transform.position.z - lockTransformZ) > 0.1f) // && Input.GetAxis("Horizontal") > 0
        {
            //Debug.Log("i am in IF statement");
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, lockTransformZ);
            GetComponent<CharacterController>().enabled = true;
        }
       /* else if (Mathf.Abs(gameObject.transform.position.z - lockTransformZ) > 0.1f) // && Input.GetAxis("Horizontal") < 0
        {
            //GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, lockTransformZ);
           // GetComponent<CharacterController>().enabled = true;
        }*/
    }

    void Freeze()
    {
        currentRunTime = 10f;
        GetComponent<CharacterController>().enabled = false;
        musicThingy.StopPlayingMusic();
        musicThingy.StartPlayingMusic();
        if (blocksToUse.Count > 0)
        {
            freezeCount = freezeCount + 1;
            GameObject freezePlayerObject = blocksToUse[0];
            Instantiate(freezePlayerObject, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Frozen").transform);
            blocksToUse.RemoveAt(0);
            ac.PlayOneShot(freezeSFX);
        }
        Respawn();
        
    }

   /* public void StartOver()
    {
        currentRunTime = 10f;
        Respawn();
        Time.timeScale = 1;
        
    }*/

    void Respawn()
    {
        gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        SetBlock();
        lockTransformZ = transform.position.z;
        GetComponent<CharacterController>().enabled = true;
        characterMove.playerSpeed = speedIncrease * characterMove.playerSpeed;
    }

    void SetBlock()
    {
        if (blocksToUse.Count > 0)
        {
            
            if(blocksToUse[0] == squareBlock)
            {
                squareCube.SetActive(true);

                longCube.SetActive(false);
                jumpCube.SetActive(false);
                horizontalCube.SetActive(false);
                verticalCube.SetActive(false);
            }
            else if (blocksToUse[0] == longBlock)
            {
                longCube.SetActive(true);

                squareCube.SetActive(false);
                jumpCube.SetActive(false);
                horizontalCube.SetActive(false);
                verticalCube.SetActive(false);
            }
            else if (blocksToUse[0] == jumpBlock)
            {
                jumpCube.SetActive(true);

                squareCube.SetActive(false);
                longCube.SetActive(false);
                horizontalCube.SetActive(false);
                verticalCube.SetActive(false);
            }
            else if (blocksToUse[0] == horizontalBlock)
            {
                horizontalCube.SetActive(true);

                jumpCube.SetActive(false);
                squareCube.SetActive(false);
                longCube.SetActive(false);
                verticalCube.SetActive(false);
            }
            else if (blocksToUse[0] == verticalBlock)
            {
                verticalCube.SetActive(true);

                horizontalCube.SetActive(false);
                jumpCube.SetActive(false);
                squareCube.SetActive(false);
                longCube.SetActive(false);
            }
        }
        else
        {
            squareCube.SetActive(false);
            longCube.SetActive(false);
            jumpCube.SetActive(false);
            horizontalCube.SetActive(false);
            verticalCube.SetActive(false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if(isOnKillTrigger && hit.gameObject.tag == "Kill")
        {
            isOnKillTrigger = false;
            Die();
        }
        else if(isOnKillTrigger)
        {
            isOnKillTrigger = false;
        }

        if (hit.gameObject.tag == "Kill")
        {
            StartCoroutine(CoyoteKill());
        }

        if (hit.gameObject.tag == "Checkpoint")
        {
            //currentRunTime = 10f;
            ac.PlayOneShot(checkpointSFX);
            Checkpoint checkpoint = hit.gameObject.GetComponentInParent<Checkpoint>();
            checkpoint.CheckpointReached();
        }

        if (hit.gameObject.tag == "Finish")
        {
            Win();
        }
    }

    IEnumerator CoyoteKill()
    {
        yield return new WaitForSeconds(coyoteKillTime);
        isOnKillTrigger = true;
    }

    public void FillTheList(SlotClass[] PriorityList)
    {
        Debug.Log("Start: ");
        for(int i = 1; i <= PriorityList.Length;i++)
        {
            foreach (SlotClass slot in PriorityList)
            {
                Debug.Log("Order number: " + slot.orderNumber);
                Debug.Log("Block number: " + slot.blockNumber);
                if (slot.orderNumber == i)
                {
                    switch (slot.blockNumber)
                    {
                        case 1:
                            blocksToUse.Add(squareBlock);
                            break;
                        case 2:
                            blocksToUse.Add(longBlock);
                            break;
                        case 3:
                            blocksToUse.Add(jumpBlock);
                            break;
                        case 4:
                            blocksToUse.Add(horizontalBlock);
                            break;
                        case 5:
                            blocksToUse.Add(verticalBlock);
                            break;
                        case 6:

                            break;
                    }
                }
            }
        }
        
        Debug.Log("END: ");
        //blocksToUse.Reverse();
        SetBlock();
    }

    void Die()
    {
        /*
        ac.PlayOneShot(deathSFX);
        ac.PlayOneShot(deathSong);
        Time.timeScale = 0f;
        blocksToUse.Clear();
        GetComponent<CharacterController>().enabled = false;
        deathScreen.SetActive(true);
        musicThingy.StopPlayingMusic();
        */

        GetComponent<CharacterController>().enabled = false;
        ac.PlayOneShot(deathSFX);
        Time.timeScale = 0f;
        musicThingy.StopPlayingMusic();

        if (blocksToUse.Count < 1)
        {

            ac.PlayOneShot(deathSong);
            deathScreen.SetActive(true);
            blocksToUse.Clear();
            currentRunTime = 10f;


        }
        else
        {
            blocksToUse.RemoveAt(0);
            ac.PlayOneShot(deathSFX);
            Time.timeScale = 1f;
            musicThingy.StartPlayingMusic();
            currentRunTime = 10f;
            Respawn();
        }

    }

    void Win()
    {
        ac.PlayOneShot(winSFX);
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        musicThingy.StopPlayingMusic();
    }

}
