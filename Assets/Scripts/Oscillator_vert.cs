using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_vert : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor = 0f;
    [SerializeField] float period = 2f;
    float timeStarted;
    Vector3 Offset;

    void Start()
    {
        startingPosition = transform.position;// + 0.5f * movementVector;
    }

    private void OnEnable()
    {
        timeStarted = Time.time + period*90;

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }

        const float tau = Mathf.PI * 2;    // constant of 6.28
        float cycles = (Time.time - timeStarted) / period;  // continually growing over time
        float rawSinWave = Mathf.Sin(cycles/tau);  // going from -1 to 1
        movementFactor = (rawSinWave + 1f) / 2f;   // adjusted for 0 to 1

        Offset = movementVector * movementFactor; 
        transform.position = startingPosition + Offset;
        /*
        Debug.Log("Time.time = " + Time.time);
        Debug.Log("cycles = " + cycles);
        Debug.Log("rawSinWave = " + rawSinWave);
        Debug.Log("MovementFactor = " + movementFactor);
        Debug.Log("Offset = " + Offset);*/

    }


}
