using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public int speed;
    public Animator anim;
    public Vector2 position;
    // Update is called once per frame
    void Update()
    {

        string a = "a";
        int layer = -1;
        if (Input.GetTouch(0).position.x >= position.x )
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.Play(a,layer);
        }
        if (Input.GetTouch(0).position.x != position.x)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            anim.Stop();
        }

        if (Input.GetTouch(1).phase == TouchPhase.Began)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }
    }
}
