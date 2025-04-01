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


    // Start is called before the first frame update
    void Start()
    {

    }
    public IEnumerator imWalkinEre() 
    {
        yield return new WaitForSeconds(1f);
        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.updateRotation = false;
        agent.autoTraverseOffMeshLink = true;
        agent.updateUpAxis = false;
        passengerPosition = GetComponentInParent<Transform>().position;
        left = (passengerPosition.x <= -5);

        if (left)
        {
            passengerPosition.x += 4;
        }
        else
        {
            passengerPosition.x -= 4;
        }
      
        agent.SetDestination(target.position);
        // Debug.Log("to aisle");
        while (true)
        {
            // Debug.Log("distance is "+agent.remainingDistance);
            if (Vector3.Distance(target.position, transform.position) < 0.1)
            {
                // Debug.Log("distance is less");

                // Debug.Log("distance is " + agent.remainingDistance);
                agent.SetDestination(bathroom.position);
                // Debug.Log("to bathroom");
                yield return new WaitForSeconds(10);
                // Debug.Log("done");
                agent.SetDestination(target.position);
                while (true) 
                {
                    // Debug.Log("distance is " + agent.remainingDistance);
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
                                yield return new WaitForSeconds(Random.Range(0,5));
                                GetComponentInParent<PassengerManager>().SelectAnnoyingPassenger();
                                yield break;
                            }
                        }
                    }
                    yield return new WaitForSeconds(.1f);
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
