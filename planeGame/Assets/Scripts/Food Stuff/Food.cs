using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Ingredient
{
    private int spriteNum;
    [SerializeField] public Sprite[] sprites;
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
        // Debug.Log("finding spriteNum");
        string temp,test;
        string nm = a[0] +" "+a[1];
        Dictionary<string,int> sprite = getSpriteList();
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
    public Sprite getSpriteImg(int a) {
        // Debug.Log("returning: "+sprites[a].name);
        return sprites[a];
    }
}
