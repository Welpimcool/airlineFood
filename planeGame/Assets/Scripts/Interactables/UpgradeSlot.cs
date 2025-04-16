using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSlot : MonoBehaviour
{
    [SerializeField] public GameObject[] upgradeList;
    bool stat; //if its a stat upgrade (cooking speed) or new interactable
    bool isEnabled = true;
    [SerializeField] int upgrade;// what upgrade it spawns (if its an interactable)
    [SerializeField] public Sprite[] spriteList;
    [SerializeField] public Sprite[] statSpriteList;
    // Start is called before the first frame update
    void Start()
    {
        if (upgrade >= 0) {
            stat = false;
        } else {
            stat = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isEnabled) {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void onInteraction() { //when being interacted with by player
        if (isEnabled) {
            if (!stat) {
                GameObject a = Instantiate(upgradeList[upgrade]);
                a.transform.position = this.transform.position;
                a.transform.parent = this.transform.parent;
            } else {
                statUpgrade(upgrade);
            }
            
            
            isEnabled = false;
        }
        
    }
    private void statUpgrade(int a) {
        if (a == -1){
            Stove.upgradeSpeed(1.5f);
        } else if (a == -2) {

        }
    }

    private void statSpriteSwap(int a) {
        this.GetComponent<SpriteRenderer>().sprite = statSpriteList[a]; //might need to times by -1 because stat nums are less than 0
    }
    private void spriteSwap(int a) {
        this.GetComponent<SpriteRenderer>().sprite = spriteList[a];
    }
}
