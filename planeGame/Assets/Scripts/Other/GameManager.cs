using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject orderSheet;
    private List<GameObject> sheets;
    private float offset = 1;
    private List<GameObject> orderList;
    // Start is called before the first frame update
    public static void lose()
    {
        Debug.Log("you lose");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        orderList = PassengerManager.orderList;
        for (int i = 0; i > PassengerManager.numOrders; i++) {
            if (orderList.Count >= i) {
                if (!(sheets.Count >= i)) {
                    sheets.Add(Instantiate(orderSheet));
                    sheets[i].transform.position = new Vector3(3f,offset*(i-1),0);
                }
                
            }
            
        }
    }
}
