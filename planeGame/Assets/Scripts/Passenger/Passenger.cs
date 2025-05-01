using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Passenger : MonoBehaviour
{
    private bool annoyed = false;
    private bool angy = false;
    private bool isOrderActive = false;
    private bool isOnCooldown = false;
    private float coolDown;
    private float maxCoolDown = 10f;
    private float timeRemaining;
    private string orderedItem;
    [SerializeField] TextMeshProUGUI orderText;
    private Sprite displaySprite;
    [SerializeField] SpriteRenderer SprRend;
    [SerializeField] GameObject foodObject;
    [SerializeField] GameObject chair;
    [SerializeField] GameObject angerIcon;
    Dictionary<string, int> foodList = new() //same as food list but only orderable items
    {
        // ["Food"] = 0,
        // ["1Meat Plate"] = 1,
        // ["1Meat Bun"] = 2,
        // ["Bun Plate"] = 3,
        ["1Meat Bun Plate"] = 4,
        ["1Meat Bun 1Cheese Plate"] = 5,
        // ["Bun 1Cheese Plate"] = 6,
        // ["Bun 1Cheese"] = 7,
        // ["1Meat Bun 1Cheese"] = 8,
    };


    void Start()
    { 
        GetComponentInChildren<Canvas>().enabled = false;
        angerIcon.SetActive(false);
    }

    void Update()
    {
        if (isOnCooldown) {
            coolDown += Time.deltaTime;
            if (coolDown >= maxCoolDown) {
                isOnCooldown = false;
            }
        }
        if (angy) {
            angerIcon.SetActive(true);
            float temp = 0.5f*Mathf.Sin(GameManager.currentDayTime*0.5f)+0.25f;
            angerIcon.transform.localScale = new Vector3(temp,temp,0);
        }
    }
    public float getTimeRemaining() //Gets time remaining in order
    {
        return timeRemaining;
    }
 
    public bool getIsOrderActive() //Gets whether the passenger has already ordered
    {
        return isOrderActive;
    }
    public bool getIsOnCooldown() //Gets whether the passenger has finished an order recently
    {
        return isOnCooldown;
    }
    
    public IEnumerator Order(float orderTime) //Processes the actual order
    {
        orderedItem = selectFood();
        // Debug.Log(orderedItem);
        bool sensitive = Random.Range(0, 2) == 1;
        float timeRemaining = orderTime;
        //Makes time tick down
        if (annoyed)
        {
            timeRemaining -= orderTime / 5;
        }
        isOrderActive = true;
        yield return new WaitForSeconds(1);
        //Prepares Meter
        GetComponentInChildren<Meter>().setMaxValue(orderTime);
        GetComponentInChildren<Canvas>().enabled = true;
        // orderText.text = orderedItem;
        displayFood();
        while (isOrderActive &&timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;
            GetComponentInChildren<Meter>().setValue(timeRemaining);
            //Makes anger increase if order took too long
            if ((timeRemaining < orderTime / 10 || (sensitive && timeRemaining < orderTime/5 && WeatherShift.weather ==1) && !annoyed))
            {
                if (!angy) 
                {
                    chair.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                annoyed = true; //maybe make it so they cannot be annoyed and angry?
            }
            //idk why this is needed but it is
            yield return null;
        }
       
        GetComponentInChildren<Canvas>().enabled = false;
        SprRend.enabled = false;
        if(isOrderActive == false)
        {
            Debug.Log("Order Stopped");
        }
        else
        {
            Debug.Log("Order Failed");
            GetComponentInParent<PassengerManager>().OrderFailed();
            if (angy)
            {
                GameManager.lose();
            }
            else
            {
                angy = true;
                annoyed = false;
                // chair.GetComponent<SpriteRenderer>().color = Color.red;
                isOrderActive = false;
                isOnCooldown = true;

            }
        }
        
    }
    public string selectFood()
    {
        string[] list = new string[2];
        int j = 0;
        foreach (string i in foodList.Keys)
        {
            list[j] = i;
            j++;
        }
        return list[Random.Range(0, 2)];
    }
    public void displayFood() {
        orderedItem = selectFood();
        Debug.Log("orderedItem:"+orderedItem);
        displaySprite = foodObject.GetComponent<Food>().getSpriteImg(findSprite(orderedItem));
        SprRend.sprite = displaySprite;
        SprRend.enabled = true;
    }

    public bool onInteraction(GameObject item) { 
        // Debug.Log(item.ToString(),item);
        if (isOrderActive) {
            Debug.Log("comparing if "+item.GetComponentInChildren<Ingredient>().getName()+" equals "+orderedItem);
            if (item.GetComponentInChildren<Ingredient>().getName().Equals(orderedItem)) {
                //mark order as complete
                isOrderActive = false;
                isOnCooldown = true;
                GetComponentInParent<PassengerManager>().OrderComplete();


                Debug.Log("order filled");
                return true; //tells player to delete item
            }
            Debug.Log("Incorrect item, needed:"+orderedItem+", gave:"+item.GetComponentInChildren<Ingredient>().getName());
        } else {
            Debug.Log("The passenger is not ordering");
        }
        return false;
    }

    public string getOrderedFood()
    {
        return orderedItem;
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

    public void disable() //disable all visual elements and if needed function ones (if not called by other scripts)
    {
        GetComponentInChildren<Canvas>().enabled = false;
        angerIcon.SetActive(false);
        SprRend.enabled = false;
    }
}
