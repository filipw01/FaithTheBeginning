using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutScript : MonoBehaviour {
    public float fadeSpeed = 1.5f;
    public new SpriteRenderer renderer;
    // Use this for initialization
    void Start()
    {
    }
    public new GameObject camera;
    public GameObject gameobject;
    public Vector3 positionMin;
    public Vector3 positionMax;
    public Color myColor;
    public Color myColor2;
    private Vector3 cameraPosition;
    private bool isFading=false;
    // Update is called once per frame
    void Update()
    {
        if (renderer.color.a >= myColor2.a)
            {
                isFading = false;
            }
        if ((gameobject.transform.position.x >= positionMin.x && gameobject.transform.position.y >= positionMin.y && 
            gameobject.transform.position.x <= positionMax.x && gameobject.transform.position.y <= positionMax.y &&
            Input.GetTouch(1).phase == TouchPhase.Began) || isFading==true)
        {
            
            renderer.color = new Color(myColor.r, myColor.g, myColor.b,myColor.a += fadeSpeed);
            isFading = true;
            
        }
        else
        {
            renderer.color = new Color(myColor.r, myColor.g, myColor.b, myColor.a -= fadeSpeed);
        }
        cameraPosition.Set(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        transform.position = cameraPosition;
    }
}
