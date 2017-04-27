using System;
using UnityEngine;
using System.Collections;

public class MyInventory : MonoBehaviour 
{
    private bool hashit = false;

	private Texture item;
	public Texture defaultTexture;
       private Collider2D PickupCollider;
       private Collider2D MainCharacterCollider;
    private GameObject pickup;
	int gridWidth = 9;
	int gridHeight = 1;
    public Texture textureOne;
    public Texture textureTwo;
    public Texture textureThree;


    bool bWeaponEquiped = false;
	bool bShieldEquiped = false;
	bool bR1Equiped = false;
	bool bR2Equiped = false;
	bool bAmuletEquiped = false;
	bool bBeltEquiped = false;
	bool bBootsEquiped = false;
	bool bGlovesEquiped = false;

    public GUIStyle lblItemDescrStyle;

    public struct Inventar
    {
        public string itemName;
        public Texture itemTexture;
        public bool drawn;
        public string opis;
        public bool occupiedCell;
        public int firstCell;
        public int textureNumber;
    }
   public Inventar[] charInventory;

    public int invL;
    public int invT;
    public string[] pickups = {"HandGrip","Sword"};

    private int textureNumer;


    void Start()
    {
        MainCharacterCollider = GetComponent<Collider2D>();
        
        charInventory = new Inventar[gridWidth * gridHeight];
        //invL = invT = 20;
    }

    void Update()
    {
         textureNumer = 0;
        foreach (var name in pickups)
        {
         
            if (MainCharacterCollider.IsTouching(GameObject.Find(name).GetComponent<Collider2D>()))
                {
                     pickup = GameObject.Find(name);
                     PickupCollider = pickup.GetComponent<Collider2D>();
                    charInventory[AddItemToInventory(pickup.GetComponent<ItemClass>())].textureNumber=textureNumer;
                     Destroy(pickup.GetComponent<SpriteRenderer>());
                     Destroy(pickup.GetComponent<Collider2D>());
                }
            textureNumer++;
        }
        
    }



    public int AddItemToInventory(ItemClass item)
    {
        int intialIndexLocation = -1; 
        if(item != null)
        {
            ItemClass temp =   item;      //Set up a temporary item to compare with

            if (SlotsRemaining() >= 1)    
            {
                bool firstFoundLocation = true;                                                    
                                                                   
                for(int i = 0; i < gridWidth; i ++) 
                {
                    for(int t = 0; t < gridHeight; t++)    
                    {
                        if (charInventory[i + (gridHeight * t)].occupiedCell != true)  
                        {
                            if (firstFoundLocation)
                            {
                                firstFoundLocation = false;

                                intialIndexLocation = i + (gridWidth * t);
                            }
                            
                        }
                    }  
                }
            }

            if (SlotsRemaining() == charInventory.Length)  
            {
                intialIndexLocation = 0; 
            }
            if(intialIndexLocation > -1) 
            {
                
              
                        charInventory[intialIndexLocation].drawn = true;
                         charInventory[intialIndexLocation].drawn = false;
                        charInventory[intialIndexLocation].itemName = item.itemName;
                        charInventory[intialIndexLocation].itemTexture = item.itemTexture;
                        charInventory[intialIndexLocation].opis = item.opis;
                        charInventory[intialIndexLocation].occupiedCell = true;
                        charInventory[intialIndexLocation].firstCell = intialIndexLocation;
                       
             
            }
        }
        return intialIndexLocation;
    }


    void DeleteFromInventory(string itmNam, int fc)
    {
        for (int i = 0; i < charInventory.Length; ++i)
        {
            if (charInventory[i].itemName == itmNam && charInventory[i].firstCell == fc)
            {
                charInventory[i].occupiedCell = false;
            }

        }
    }

    void OnGUI()
    {


        //=======================================================character inventory=========================================
        for(int i = 0; i < gridWidth; i ++) 
        {  
            for(int t = 0; t < gridHeight; t++)
            {
                if (charInventory[i + (gridHeight * t)].occupiedCell != true)
                {
                    GUI.DrawTexture(new Rect((invL + (i * 30)), invT + (t * 30), 30, 30), defaultTexture);
                }
                else
                {
                    Inventar temp = charInventory[i + (gridHeight * t)];
                    if(!temp.drawn)
                    {
                        switch (temp.textureNumber)
                        {
                            case 0:
                                GUI.DrawTexture(new Rect((invL + (i * 30)), invT + (t * 30), 30, 30), textureOne);
                                temp.drawn = true;
                                break;
                            case 1:
                                GUI.DrawTexture(new Rect((invL + (i * 30)), invT + (t * 30), 30, 30), textureTwo);
                                temp.drawn = true;
                                break;
                            case 2:
                                GUI.DrawTexture(new Rect((invL + (i * 30)), invT + (t * 30), 30, 30), textureThree);
                                temp.drawn = true;
                                break;

                        }
                        
                    }
                }
            }
        }
    }
    public int SlotsRemaining()
    {
        int count = 0;
        for (int i = 0; i < charInventory.Length; i++)
        {
            if (charInventory[i].occupiedCell != true)
            {
                count++;
            }
        }
        return count;
    }

}

     
