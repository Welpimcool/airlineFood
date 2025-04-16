using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Ingredient
{
    private int spriteNum;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale,scale,0);
        if (!prop) {
        // this.setScale(1);
        this.setState(0);
        this.setValue(0);
        this.setCook(false);
        // this.setName("Food");
        this.setList(new string[] {""});
        }
        spriteNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string findSprite(string[] a) {
        Debug.Log("finding spriteNum");
        string temp;
        string nm = a[0] +" "+a[1];
        Dictionary<string,int> sprite = this.getSpriteList();
    //     Debug.Log("looking through "+sprite.Keys.Count+" diffrent strings");
    //     foreach(string i in sprite.Keys) { //goes through all food items
    //         Debug.Log("looking through string:"+i);
    //         temp = i;
    //         foreach(string j in a) { // for both combining ingredients
    //             Debug.Log("removing instances of "+j);
    //             temp = temp.Replace(j,""); //remove ingredient names from food item
    //             Debug.Log("new string: "+temp);
    //         }
    //         temp = temp.Replace(" ","");
    //         Debug.Log("turned string: "+i+" into string: "+temp);
    //         if (temp.Equals("")) { //if all ingredients are removed, it contains all ingredients
    //             spriteNum = sprite[i];
    //             spriteRenderer.sprite = sprites[spriteNum];
    //             return i;
    //         }
            
    //     }
    //     return "";
    foreach (string i in sprite.Keys) { //for each food
            Debug.Log("looking through string:"+nm);
            temp = nm;
            foreach(string j in i.Split(" ")) {
                Debug.Log("removing instances of "+j);
                temp = temp.Replace(j,""); //remove instances of the food ingredients from the name
                Debug.Log("new string: "+temp);
            }
            temp = temp.Replace(" ","");
            Debug.Log("turned string: "+nm+" into string: "+temp);
            if (temp.Equals("")) {
                spriteNum = sprite[i];
                spriteRenderer.sprite = sprites[spriteNum];
                return i;
            }  
        }
        return "";
    }

    public int getSpriteNum() {
        return spriteNum;
    }
}
