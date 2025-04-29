using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
        if (isLanding) { //play landing animation

        } else { //play taking off animation

        }
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransition) {
            transTimer += Time.deltaTime;
            if (transTimer >= 1f || Input.GetKeyDown(KeyCode.Escape)) { //change timer to fit with animation (maybe make if isLanding if animations take diff times)
                if (isLanding) { //go to after day scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } else { //go to Day scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
                
            }
        }
    }
}
