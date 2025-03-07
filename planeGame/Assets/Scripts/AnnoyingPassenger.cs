using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingPassenger : MonoBehaviour
{
    public bool left;
    public Vector3 passengerPosition;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        passengerPosition = GetComponentInParent<Transform>().position;
        left = (passengerPosition.x <= -5);
        imWalkinEre();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator imWalkinEre() 
    {
        //if(left)
        //{
        //    passengerPosition.x += 4;
        //}
        //else
        //{
        //    passengerPosition.x -= 4;
        //}
        agent.SetDestination(target.position);

        yield return null;
    }
}
