using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;

    [HideInInspector]
    public float xAxis;
    private float yAxis;

    [SerializeField]
    private float jumpForce = 200f;
    private int groundMask;
    private bool isGrounded;
    private bool isJumpPressed;
    private bool isFacingRight = true;
    private bool isDead;
    private Rigidbody2D rgbd;
    private Animator anim;

    Vector3 localScale;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        localScale = transform.localScale;
        isDead = false;
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

    }

    private void LateUpdate()
    {
        Flip();
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            //Check whether or not the player is on the ground
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, groundMask);

            if (hit.collider != null)
            {
                isGrounded = true;
            }
            else isGrounded = false;

            //Check update movement based on input
            Vector2 vel = new Vector2(0, rgbd.velocity.y);

            if (xAxis < 0)
            {
                vel.x = -moveSpeed;
                anim.SetFloat("Speed", moveSpeed);
                isFacingRight = false;
            }
            else if (xAxis > 0)
            {
                vel.x = moveSpeed;
                anim.SetFloat("Speed", moveSpeed);
                isFacingRight = true;
            }
            else
            {
                vel.x = 0;
                anim.SetFloat("Speed", 0f);
            }


            if (isJumpPressed && isGrounded)
            {
                rgbd.AddForce(new Vector2(0, jumpForce));
                isJumpPressed = false;
            }

            rgbd.velocity = vel;

            if (rgbd.velocity.y > 0.1)
            {
                anim.SetBool("isJumping", true);
            }
            else if (rgbd.velocity.y < -0.1)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", false);
            }
        }
    }

    private void Flip()
    {
        if ((isFacingRight && localScale.x < 0) || (!isFacingRight && localScale.x > 0))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    public void Dead()
    {
        isDead = true;
        anim.SetBool("isFalling", false);
        anim.SetTrigger("Dead");
        this.enabled = false;
    }

    public void PlayFootstep()
    {
        FindObjectOfType<AudioManager>().Play("Footstep");
    }

    //Play landed sound
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            FindObjectOfType<AudioManager>().Play("Landing");
        }
    }
}
