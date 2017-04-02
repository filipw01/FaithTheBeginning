using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutScript : MonoBehaviour {
    public float fadeSpeed = 1.5f;
    private bool sceneStarting = true;
    public new SpriteRenderer renderer;
    // Use this for initialization
    void Start()
    {

    }
    public new GameObject camera;
    public GameObject gameobject;
    public Vector3 positionMin;
    public Vector3 positionMax;
    private Color myColor;
    private bool isFading;
    // Update is called once per frame
    void Update()
    {
        if ((gameobject.transform.position.x >= positionMin.x && gameobject.transform.position.y >= positionMin.y && 
            gameobject.transform.position.x <= positionMax.x && gameobject.transform.position.y <= positionMax.y && 
            Input.GetTouch(1).phase == TouchPhase.Began) || isFading==true)
        {
            myColor = renderer.color;
            renderer.color = new Color(myColor.r, myColor.g, myColor.b,myColor.a += fadeSpeed);
            isFading = true;
        }
        transform.position = camera.transform.position;
    }
}
