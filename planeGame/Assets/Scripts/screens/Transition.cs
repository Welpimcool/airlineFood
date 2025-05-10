using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public bool isTransition = true;
    public float transTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isTransition) {
            transTimer += Time.deltaTime;
            if (transTimer >= 7f || Input.GetKeyDown(KeyCode.Escape)) { //change timer to fit with animation
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
