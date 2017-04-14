using UnityEngine;
using System.Collections;

public class MyInventory : MonoBehaviour 
{
    private bool hashit = false;

	public Texture item;
	public Texture defaultTexture;
       public Collider2D PickupCollider;
       public Collider2D MainCharacterCollider;
    public GameObject pickup;
	int gridWidth = 4;
	int gridHeight = 3;
   

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
    }
   public Inventar[] charInventory;

    public int invL;
    public int invT;


    void Start()
    {
        charInventory = new Inventar[gridWidth * gridHeight];
        //invL = invT = 20;
    }

    void Update()
    {
        if (MainCharacterCollider.IsTouching(PickupCollider))
        {
            AddItemToInventory(pickup.GetComponent<ItemClass>());
            Destroy(pickup.GetComponent<SpriteRenderer>());
            Destroy(pickup.GetComponent<PolygonCollider2D>());
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
                                                                 
                int count = 0;                                   
                                                                   
                for(int i = 0; i < gridWidth; i ++) 
                {
                    for(int t = 0; t < gridHeight; t++)    
                    {
                        if (charInventory[i + (gridHeight * t)].occupiedCell != true)  
                        {         
                            for(int j = 0; j < 1; j++)                
                            {
                                
                                    for( int k = 0; k < 1; k++)   
                                    {
                                        if (charInventory[i + (gridHeight * (t + k)) + j].occupiedCell != true)
                                        {
                                            if(firstFoundLocation) 
                                            {
                                                firstFoundLocation = false; 
                                                                            
                                                intialIndexLocation = i+(gridWidth*t); 
                                            }
                                            count+=1;     
                                            if(count == 1)
                                            {
         
                                                break;
                                            }
                                        }
                                    }
                            }
                            if(count >= 1)
                            {
                                break;
                            } else if(count < 1)
                            {
                                firstFoundLocation = true;
                                count = 0;
                                intialIndexLocation = -1;
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
                bool whentodraw=true;
                for(int i = 0; i < 1; i++)
                {
                    for(int t = 0; t < 1; t++)
                    {

                        charInventory[intialIndexLocation + i + (gridHeight * t)].drawn = true;
                        if (whentodraw) charInventory[intialIndexLocation + i + (gridHeight * t)].drawn = false;
                        charInventory[intialIndexLocation + i + (gridHeight * t)].itemName = item.itemName;
                        charInventory[intialIndexLocation + i + (gridHeight * t)].itemTexture = item.itemTexture;
                        charInventory[intialIndexLocation + i + (gridHeight * t)].opis = item.opis;
                        charInventory[intialIndexLocation + i + (gridHeight * t)].occupiedCell = true;
                        charInventory[intialIndexLocation + i + (gridHeight * t)].firstCell = intialIndexLocation;
                        whentodraw=false;
                    }
                }
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

           
    string txtWidth = "";
    string txtHeight = "";
           
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
                        GUI.DrawTexture(new Rect((invL + (i * 30)), invT + (t * 30), 30, 30), item);
                        temp.drawn = true;
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

     
