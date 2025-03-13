using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingPassenger : MonoBehaviour
{
    private Vector3 origin;
    private bool left;
    private Vector3 passengerPosition;
    private NavMeshAgent agent;
    public static Transform target;
    public static Transform bathroom;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        passengerPosition = GetComponentInParent<Transform>().position;
        left = (passengerPosition.x <= -5);
    }

    // Update is called once per frame
    void Update()
    {
        //if (passengerPosition.y == target.position.y)
        //{
        //    Debug.Log("Here");
        //}
        //if (agent.remainingDistance < 0.1)
        //{
        //    if (i == 0)
        //    {
        //        agent.SetDestination(bathroom.position);
        //        StartCoroutine(bathroomBreak());
        //        i = 1;
        //    }
        //}
    }

    public IEnumerator imWalkinEre() 
    {
        if (left)
        {
            passengerPosition.x += 4;
        }
        else
        {
            passengerPosition.x -= 4;
        }
        yield return new WaitForSeconds(1f);
        agent.SetDestination(target.position);
        Debug.Log("to aisle");
        while (true)
        {
            if (agent.remainingDistance < 0.1)
            {
                if (i == 0)
                {
                    agent.SetDestination(bathroom.position);
                    Debug.Log("to bathroom");
                    i = 1;
                    yield return new WaitForSeconds(10);
                    Debug.Log("done");
                    agent.SetDestination(target.position);
                    while (true) 
                    { 
                        if (agent.remainingDistance < 0.1)
                        {
                            agent.SetDestination(origin);
                            while (true)
                            {
                                yield return new WaitForSeconds(.1f);
                                if (agent.remainingDistance < 0.1)
                                {
                                    agent.enabled = false;
                                    transform.position = origin;
                                    yield break;
                                }
                            }
                        }
                        yield return new WaitForSeconds(.1f);
                    }
                        
                }
                
            }
            yield return new WaitForSeconds(0.1f);
         
        }
    }
    //IEnumerator bathroomBreak()
    //{
    //    Debug.Log("starting");
        
        
    //}
    
}
