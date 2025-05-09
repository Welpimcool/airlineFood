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
    private Animator anim;
    private SpriteRenderer spr;


// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        anim.SetInteger("State",0);
        Debug.Log("Start set state to zero");
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
        // anim.SetInteger("State",1);
        Debug.Log("to aisle");
//Checks whether it is at desired position, changes target
        while (true)
        {
            // Debug.Log("distance is "+agent.remainingDistance);
            if (Vector3.Distance(target.position, transform.position) < 0.1)
            {
                // Debug.Log("distance is less");

                // Debug.Log("distance is " + agent.remainingDistance);
                // anim.SetInteger("State",2);
                agent.SetDestination(bathroom.position);
                
                Debug.Log("to bathroom");
                yield return new WaitForSeconds(10);
                // Debug.Log("done");
//Changes destination back to aisle after bathroom
                agent.SetDestination(target.position);
                // anim.SetInteger("State",3);
//Checks whether it is at desired position, changes target
                while (true) 
                {
                    // Debug.Log("distance is " + agent.remainingDistance);
                    if (agent.remainingDistance < 0.1)
                    {
//Changes destination back to seat
                        agent.SetDestination(origin);
                        // anim.SetInteger("State",4);
//Checks whether it is at desired position, changes target
                        while (true)
                        {
                            yield return new WaitForSeconds(.1f);
                            if (agent.remainingDistance < 0.1)
                            {
                                // anim.SetInteger("State",0);
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
    void Update() {
        if (agent != null) {
            float angleInDegrees = Mathf.Atan2(agent.desiredVelocity.y, agent.desiredVelocity.x) * Mathf.Rad2Deg;
            float angle = (float)Mathf.Repeat(angleInDegrees, 360f);
            Debug.Log("Angle: "+angle);
            if (angle == 0) {
                anim.SetInteger("State",0);
            } else if ((angle >= 315 && angle <= 360) || (angle >= 0 && angle <= 45)) {
                anim.SetInteger("State",2); //was 3
                spr.flipX = true;
            } else if (angle > 45 && angle < 135) {
                anim.SetInteger("State",4);
                spr.flipX = false;
            } else if (angle >= 135 && angle <= 225) {
                anim.SetInteger("State",2);
                spr.flipX = false;
            } else if (angle > 225 && angle < 315) {
                anim.SetInteger("State",1);
                spr.flipX = false;
            }
            Debug.Log("state: "+anim.GetInteger("State"),this);
        }
        
    }
}
