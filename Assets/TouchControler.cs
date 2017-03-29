using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TouchControler : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    bool facingRight = true;
    public int speed;
    public Animation anim;
    public Animator animator;
    public Vector2 position;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetTouch(2).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("scene");
        }
        if (Input.GetTouch(0).position.x >= position.x )
        {
            if (facingRight)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }
        if (Input.GetTouch(0).position.x <= position.x )
        {
            if (!facingRight)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }
        if (Input.GetTouch(0).position.x <= position.x || Input.GetTouch(0).position.x >= position.x)
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);

        if (Input.GetTouch(1).phase == TouchPhase.Began || Input.GetKey(KeyCode.Space))
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
