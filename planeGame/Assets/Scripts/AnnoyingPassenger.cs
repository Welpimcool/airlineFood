using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingPassenger : MonoBehaviour
{
    public Vector3 origin;
    public bool left;
    public Vector3 passengerPosition;
    NavMeshAgent agent;
    [SerializeField] Transform transform;
    [SerializeField] Transform target;
    [SerializeField] Transform bathroom;
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
        StartCoroutine(imWalkinEre());
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

    IEnumerator imWalkinEre() 
    {
        if (left)
        {
            passengerPosition.x += 4;
        }
        else
        {
            passengerPosition.x -= 4;
        }
        agent.SetDestination(target.position);
        while (true)
        {
            if (passengerPosition.y == target.position.y)
            {
                Debug.Log("Here");
            }
            if (agent.remainingDistance < 0.1)
            {
                if (i == 0)
                {
                    agent.SetDestination(bathroom.position);
                    i = 1;
                    yield return new WaitForSeconds(10);
                    Debug.Log("done");
                    agent.enabled = false;
                    transform.position = origin;

                
                    break;
                }
                
            }
            yield return new WaitForSeconds(0.1f);
         
        }
        yield return null;
    }
    //IEnumerator bathroomBreak()
    //{
    //    Debug.Log("starting");
        
        
    //}
    
}
