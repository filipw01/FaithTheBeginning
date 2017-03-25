using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }

        if (Input.GetTouch(1).phase == TouchPhase.Began)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
        }
    }
}
