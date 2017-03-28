using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
    }
    public int speed;
    public Animation anim;
    public Vector2 position;
    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if (Input.GetTouch(0).position.x >= position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.Play();
        }
        if (Input.GetTouch(0).position.x <= position.x)
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
