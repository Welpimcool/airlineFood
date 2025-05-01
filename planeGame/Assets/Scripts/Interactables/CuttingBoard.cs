using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField] GameObject Knife;
    public static float speed = 1f;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            var r = Knife.transform.eulerAngles;
            Knife.transform.rotation = UnityEngine.Quaternion.Euler(r.x, r.y, 45*Mathf.Sin(GameManager.currentDayTime)+45);
        } else {
            Knife.transform.rotation = UnityEngine.Quaternion.Euler(0,0,0);
        }
        isMoving = false;
    }
    public static float getSpeed() {
        return speed;
    }
    public static void setSpeed(float a) {
        speed = a;
    }
    // public void toggleAnimation() {
    //     if (isMoving) {
    //         isMoving = false;
    //     } else {
    //         isMoving = true;
    //     }
    // }
    public void setAnimation(bool a) {
        isMoving = a;
    }
}
