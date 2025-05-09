using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject pos;
    public static float speed = 1f;
    public bool isMoving = false;
    public ParticleSystem cuttingBoardParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            var r = Knife.transform.eulerAngles;
            Knife.transform.rotation = UnityEngine.Quaternion.Euler(r.x, r.y, 45*Mathf.Sin(5*GameManager.currentDayTime)-45);
            var emission = cuttingBoardParticles.emission;
            emission.enabled = true;
        } else {
            Knife.transform.rotation = UnityEngine.Quaternion.Euler(0,0,0);
            var emission = cuttingBoardParticles.emission;
            emission.enabled = false;
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
    public void toPos(GameObject item, float scale) {
        item.transform.position = pos.transform.position;
        item.transform.rotation = pos.transform.rotation;
        item.transform.localScale = new UnityEngine.Vector3(scale*75,scale*75,1);
    }
}
