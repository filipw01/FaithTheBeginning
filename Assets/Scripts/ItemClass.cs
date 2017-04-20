using UnityEngine;
using System.Collections;
[System.Serializable]
public class ItemClass : MonoBehaviour 
{
    private Collider2D PickupCollider;
    private Collider2D MainCharacterCollider;
    public string itemName;
    public Texture itemTexture;
	public bool drawn = false;
    public string opis;
    public bool isEquiped = false;
   
}


