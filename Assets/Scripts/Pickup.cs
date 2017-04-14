using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

}
	    public Collider2D PickupCollider;
        public Collider2D MainCharacterCollider;
	// Update is called once per frame
	void Update () {
        if (MainCharacterCollider.IsTouching(PickupCollider))
        {
            Destroy(gameObject);
        }
        
    }
}
