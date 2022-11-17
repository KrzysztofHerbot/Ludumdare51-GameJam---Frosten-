using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove25D : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 0.5f;
    [SerializeField] float jumpForce = 0.5f;
    [SerializeField] float gravity = -1f;
    [SerializeField] float onBoostPlatformForce = 10f;
    [SerializeField] float coyoteTime = 0.1f;
    Vector3 platformDirection;
    bool isAbleToJump;

    CharacterController controler;
    //public CharacterController Controler { get { return controler; } }
    Vector3 direction;
    AudioSource ac;
    public Vector3 Direction { get { return direction; } }
    // bool isDoubleJumpUsed = true;
    // bool isJumping;

    [Header("Sound effects")]
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip springSFX;

    void Start()
    {
        ac = GetComponent<AudioSource>();
        controler = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        Move();
        
    }

    void Move()
    {
        direction.x = Input.GetAxis("Horizontal") * playerSpeed + platformDirection.x;
        platformDirection.x = 0f;
        if (!controler.isGrounded)
        {
            direction.y = direction.y + gravity * Time.deltaTime;
        }
        //direction.y = direction.y + gravity * Time.deltaTime;
        Jump();
        if (controler.enabled == true)
        {
            controler.Move(direction * Time.deltaTime);
        }
    }

    void Jump()
    {
        if(controler.isGrounded)
        {
            isAbleToJump = true;
        }
        else
        {
            StartCoroutine(CoyoteJump());
        }

        if (Input.GetButtonDown("Jump") && isAbleToJump)  // && controler.isGrounded -old code before coyote jump added
        {
            ac.PlayOneShot(jumpSFX);
            direction.y = jumpForce;
            //isDoubleJumpUsed = false;
            //isJumping = true;
        }
       /* else if(Input.GetButtonDown("Jump") && !isDoubleJumpUsed)
        {
            direction.y = jumpForce;
            isDoubleJumpUsed = true;
            isJumping = true;
        }*/
        if (Input.GetButtonUp("Jump"))
        {
            //isJumping = false;
            if (direction.y >= 0f)
            {
                direction.y = 0f;
            }
        }

    }

    IEnumerator CoyoteJump()
    {

        yield return new WaitForSeconds(coyoteTime);
        isAbleToJump = false;
    }

    public void JumpBoost(float jumpBoostForce)
    {
        ac.PlayOneShot(springSFX);
        direction.y = jumpBoostForce;
    }

    public void ChangeOffset(Vector3 Offset)
    {
        direction = direction + Offset;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Boost")
        {
            hit.gameObject.GetComponentInChildren<Animator>().SetTrigger("JumpBoost");
            JumpBoost(onBoostPlatformForce);
        }
        else if (hit.gameObject.tag == "Moving")
        {
            platformDirection = hit.gameObject.GetComponent<Oscillator>().GiveOffset();
            Debug.Log("MY VECTORS: " + hit.gameObject.GetComponent<Oscillator>().GiveOffset());  //I give up...
        }
    }


}
