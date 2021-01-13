using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float speed;
    [SerializeField] public int health;
    [SerializeField] private float maxDist; //the maximum distance away the player can be for the koopa to throw punches
    public bool OutOfPipe = false;
    private bool IsPunching = false;
    private int hitTime = 0;

    private BoxCollider boxCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            Movement();
            if (IsPunching)
            {
                Hitting();
            }
        }
        else
        {
            animator.SetBool("dead", true);
            Destroy(gameObject); //guess who couldn't get the die animation to work?
            //unity becomes really draining sometimes
        }
    }

    private void Movement()
    {
        if (OutOfPipe)
        {
            transform.LookAt(player.transform);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 90, transform.localEulerAngles.z);
        }
        if(Vector3.Distance(transform.position, player.transform.position) <= maxDist && !IsPunching)
        {
            animator.SetBool("Hitting", true);
            IsPunching = true;
            hitTime = 0;
        }
        if(Vector3.Distance(transform.position, player.transform.position) > maxDist)
        {
            IsPunching = false;
            animator.SetBool("Hitting", false);
        }
        transform.position += -transform.right*speed*Time.deltaTime;
    }

    private void Hitting()
    {
        hitTime++;
        if(hitTime >= 48)
        {
            player.GetComponent<PlayerMovement>().health--;
            hitTime = 0;
        }
    }
}
