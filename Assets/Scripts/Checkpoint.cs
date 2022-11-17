using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject flagPole;
    public void CheckpointReached()
    {
        GameObject Respawn = GameObject.FindGameObjectWithTag("Respawn");
        Instantiate(flagPole, Respawn.transform.position, Quaternion.identity , GameObject.FindGameObjectWithTag("Frozen").transform);
        Respawn.transform.position = transform.position;
        Destroy(gameObject);
    }
}
