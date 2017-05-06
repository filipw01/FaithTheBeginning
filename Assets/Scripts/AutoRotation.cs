using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.autorotateToPortrait = true;

        Screen.autorotateToPortraitUpsideDown = true;

        Screen.orientation = ScreenOrientation.AutoRotation;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
