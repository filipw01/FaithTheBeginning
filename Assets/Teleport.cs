using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
    public Rigidbody2D rb;
    public Vector3 positionMin;
    public Vector3 positionMax;
    // Update is called once per frame
    void Update () {
        if (rb.position.x >= positionMin.x && rb.position.y >= positionMin.y && rb.position.x <= positionMax.x &&
            rb.position.y <= positionMax.y && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            
            rb.position = GameObject.Find("teleport").transform.position;
        }
	}
}
