using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]CharacterMove25D characterMove;
    Animator anim;
    Vector3 direction;
    CharacterController controller;
    void Start()
    {
        anim = GetComponent<Animator>();
        direction = characterMove.Direction;
        controller = GetComponentInParent<CharacterController>();
    }

    void Update()
    {
        if(!controller.isGrounded)
        {
            anim.SetBool("IsJumping", true);
        }
        else anim.SetBool("IsJumping", false);

        if (Input.GetAxis("Horizontal")<0f)
        {
            anim.SetBool("IsRunningLeft", true);
        }
        else anim.SetBool("IsRunningLeft", false);

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("IsRunningRight", true);
        }
        else anim.SetBool("IsRunningRight", false);
    }
}
