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
        this.setName("Food");
        this.setList(new string[] {""});
        }
        spriteNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void findSprite(string[] a) {
        Debug.Log("finding spriteNum");
        string temp;
        Dictionary<string,int> sprite = this.getSpriteList();
        Debug.Log("looking through "+sprite.Keys.Count+" diffrent strings");
        foreach(string i in sprite.Keys) {
            Debug.Log("looking through string:"+i);
            temp = i;
            foreach(string j in a) {
                Debug.Log("removing instances of "+j);
                temp = temp.Replace(j,"");
                Debug.Log("new string: "+temp);
            }
            temp = temp.Replace(" ","");
            Debug.Log("turned string: "+i+" into string: "+temp);
            if (temp.Equals("")) {
                this.setName(i);
                spriteNum = sprite[i];
                spriteRenderer.sprite = sprites[spriteNum];
            }
            
        }
    }

    public int getSpriteNum() {
        return spriteNum;
    }
}
