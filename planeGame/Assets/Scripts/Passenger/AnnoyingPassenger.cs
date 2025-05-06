using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingPassenger : MonoBehaviour
{
    private Vector3 origin;
    private bool left;
    private NavMeshAgent agent;
    public static Transform target;
    public static Transform bathroom;


// Start is called before the first frame update
    void Start()
    {

    }
    public IEnumerator imWalkinEre(PassengerManager man) 
    {
//Waits to make sure every thing else is initialized, sets origin, initializes agent
        yield return new WaitForSeconds(1f);
        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.updateRotation = false;
        agent.autoTraverseOffMeshLink = true;
        agent.updateUpAxis = false;

//Sets agent target to the aisle to the right of the bathroom
        agent.SetDestination(target.position);
        // Debug.Log("to aisle");
//Checks whether it is at desired position, changes target
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
//Changes destination back to aisle after bathroom
                agent.SetDestination(target.position);
//Checks whether it is at desired position, changes target
                while (true) 
                {
                    // Debug.Log("distance is " + agent.remainingDistance);
                    if (agent.remainingDistance < 0.1)
                    {
//Changes destination back to seat
                        agent.SetDestination(origin);
//Checks whether it is at desired position, changes target
                        while (true)
                        {
                            yield return new WaitForSeconds(.1f);
                            if (agent.remainingDistance < 0.1)
                            {
                                agent.enabled = false;
                                transform.position = origin;
                                GetComponentInParent<Passenger>().setIsWalking(false);
                                GetComponentInParent<Passenger>().setIsOnCooldown(true);
                                yield return new WaitForSeconds(Random.Range(0,5));
                                man.SelectAnnoyingPassenger();
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
}
