using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    [SerializeField] GameObject music;
    // Start is called before the first frame update
    public void MusicOff()
    {
        music.GetComponent<MusicManager>().AudioOff();
    }
    public void MusicOn()
    {
        music.GetComponent<MusicManager>().AudioBackOn();
    }
}
