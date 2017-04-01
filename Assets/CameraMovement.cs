using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public Vector3 margin;
    Vector3 notMovingUp;

	// Use this for initialization
	void Start () {
        offset.x = transform.position.x - player.transform.position.x +margin.x;
	}
	
	// Update is called once per frame
	void Update () {
        notMovingUp.Set(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = notMovingUp+offset;
	}
}
