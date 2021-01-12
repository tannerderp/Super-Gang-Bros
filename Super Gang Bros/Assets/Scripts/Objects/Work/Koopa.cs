using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float speed;
    [SerializeField] public int health;
    public bool OutOfPipe = false;

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
        transform.position += -transform.right*speed*Time.deltaTime;
    }

}
