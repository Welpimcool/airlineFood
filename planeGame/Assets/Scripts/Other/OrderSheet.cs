using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSheet : MonoBehaviour
{
    [SerializeField] GameObject foodObject;
    private Sprite displaySprite;
    [SerializeField] SpriteRenderer SprRend;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DispSprite(string str) {
        if (str != "") {
            displaySprite = foodObject.GetComponent<Food>().getSpriteImg(findSprite(str));
            SprRend.sprite = displaySprite;
            SprRend.enabled = true;
        } else {
            SprRend.enabled = false;
        }
        
    }
    public int findSprite(string nm) {
        // Debug.Log("finding spriteNum");
        string temp,test;
        // string nm = a[0] +" "+a[1];
        Dictionary<string,int> sprite = Ingredient.getSpriteList();
        foreach (string i in sprite.Keys) { //for each food
            // Debug.Log("looking through string:"+nm);
            temp = nm;
            foreach(string j in i.Split(" ")) {
                if (temp.Replace(" ","").Equals("")) {
                    // Debug.Log("EARLY STOP");
                    temp = "food"; //should stop it from triggering
                }
                // Debug.Log("removing instances of "+j);
                test = temp;
                temp = temp.Replace(j,""); //remove instances of the food ingredients from the name
                if (temp.Equals(test)) {
                    // Debug.Log("ingredient not found");
                    temp = "food"; //should stop it from triggering
                }
                // Debug.Log("new string: "+temp);
            }
            temp = temp.Replace(" ","");
            // Debug.Log("turned string: "+nm+" into string: "+temp);
            if (temp.Equals("")) {
                return sprite[i];
            }  
        }
        return 0;
    }
}
