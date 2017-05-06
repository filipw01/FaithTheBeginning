using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine;

public class TouchControler : MonoBehaviour{
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rotator = new Quaternion(0, 0, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        position.Set(Screen.width / 2, Screen.height / 2);
    }
    private Quaternion rotator;
    bool facingRight = true;
    public int speed;
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 position;
    public bool enableAds = false;
    public float time;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotator;
        if (Input.GetTouch(0).position.x > position.x)
        {
            if (facingRight)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }
        if (Input.GetTouch(0).position.x < position.x)
        {
            if (!facingRight)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else Flip();
        }
        if (Input.GetTouch(0).phase == TouchPhase.Moved|| Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            animator.SetBool("IsWalking", true);
        }else animator.SetBool("IsWalking", false);

        if (Input.GetTouch(1).phase == TouchPhase.Began && time < Time.time - 0.9)
        {
            time = Time.time;
            rb.AddForce(new Vector3(0, 3.5f, 0), ForceMode2D.Impulse);
        }
        if (Input.GetTouch(2).phase == TouchPhase.Began)
        {
            if (Advertisement.IsReady()&&enableAds)
            {
                Advertisement.Show();
                
            }SceneManager.LoadScene("scene");
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
