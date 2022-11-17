using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveTOPDOWN : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f;
    float horizontal;
    float vertical;
    Rigidbody rigidBody;
    Camera cameraPlayer;

    Ray rayLookAt;
    RaycastHit hit;
    Vector3 direction;
    Vector3 movement;
    Vector3 lookPosition;

    void Start()
    {
        cameraPlayer = GetComponentInChildren<Camera>();
        rigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        LookAtCursor(); // breaks the camera
    }

    void FixedUpdate()
    {

        Move();

    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement.x = horizontal;
        movement.z = vertical;

        rigidBody.AddForce(movement * playerSpeed / Time.deltaTime);
    }


    void LookAtCursor()
    {
        rayLookAt = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(rayLookAt, out hit, 100))
        {
            lookPosition = hit.point;
        }

        Vector3 lookDirection = lookPosition - transform.position;
        lookDirection.y = 0f;

        transform.LookAt(transform.position + lookDirection, Vector3.up);
    }     
}



