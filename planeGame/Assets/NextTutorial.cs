using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTutorial : MonoBehaviour
{
    private float time = 0;

    // Start is called before the first frame update
    private void Update()
    {
        time += Time.deltaTime;

        if (time > 4f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
