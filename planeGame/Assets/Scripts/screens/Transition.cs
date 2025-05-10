using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static bool isTransition = true;
    public static float transTimer = 0f;
    public static bool isLanding;
    // Start is called before the first frame update
    void Start()
    {
        playAnimation();
    }

    private void playAnimation()
    {
        //play landing animation (if no time for animation make a basic day end screen)
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransition) {
            transTimer += Time.deltaTime;
            if (transTimer >= 1f || Input.GetKeyDown(KeyCode.Escape)) { //change timer to fit with animation
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                
            }
        }
    }
}
