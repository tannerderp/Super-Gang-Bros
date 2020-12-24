using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardVel;
    [SerializeField] float turnSensitivity;
    [SerializeField] float jumpVel;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody rigidBody;
    private Animator animator;
    private BoxCollider collider;

    private float forwardInput;
    private float distToGround;
    private bool grounded = false;
    private int jumpCooldown = 0; //WHY DO I NEED TO MAKE A COOLDOWN FOR EVERYTHING

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        distToGround = collider.size.y/2 * transform.localScale.y + transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        if (forwardInput != 0)
        {
            var horizontalVel = -transform.right * forwardInput * forwardVel;
            rigidBody.velocity = new Vector3(horizontalVel.x, rigidBody.velocity.y, horizontalVel.z);
        }
        animator.SetFloat("Speed", Mathf.Abs(forwardInput * forwardVel));
    }

    private void Jump()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(transform.up * jumpVel);
            grounded = false;
            animator.SetBool("Jumping", true);
            jumpCooldown = 0;
        }
        jumpCooldown++;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            if (jumpCooldown > 20)
            {
                animator.SetBool("Jumping", false);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = false;
        }
    }
}
