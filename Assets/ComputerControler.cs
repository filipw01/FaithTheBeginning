using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerControler : MonoBehaviour {
   // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    bool facingRight = true;
    public int speed;
    public Animator animator;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (facingRight)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!facingRight)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
        }else animator.SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
