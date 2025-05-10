using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject onInteraction() {
        if (SceneManager.GetActiveScene().buildIndex != 3) {
            return ingredient;
        }
        else {
            return null;
        }
    }
}
