using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public Vector3 margin;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position +margin;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
