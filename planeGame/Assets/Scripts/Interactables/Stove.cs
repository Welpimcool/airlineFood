using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Table
{
    public ParticleSystem stoveParticleSystem;
    public static float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        setBody(GetComponent<Rigidbody2D>());
        offset = new Vector3(0,0.25f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (getHolding() != null) {
            var emissionModule = stoveParticleSystem.emission;
            emissionModule.enabled = true;
            if (getHolding().GetComponent<Ingredient>().getCook()) {
                getHolding().GetComponentInChildren<Ingredient>().addValue(Time.deltaTime*speed);
            }
            if (getHolding().GetComponentInChildren<Ingredient>().getState() > getHolding().GetComponentInChildren<Ingredient>().getMaxState()) {
                kill();
                Debug.Log("burned food, state:"+GetComponentInChildren<Ingredient>().getState());
            }
        }
        else
        {
            var emissionModule = stoveParticleSystem.emission;
            emissionModule.enabled = false;
        }
    }
    public static void upgradeSpeed(float spd) {
        speed = spd;
    }
}
