using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VolumeChange : MonoBehaviour
{
    public void volumeDown()
    {
        if (AudioListener.volume >= 0)
        {
            AudioListener.volume -= .10f;
        }
        
    }
    public void volumeUp()
    {
        if (AudioListener.volume <= 100)
        {
            AudioListener.volume += .10f;
        }

    }
}
