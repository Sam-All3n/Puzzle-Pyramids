using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class RiddleMasterNav : MonoBehaviour {

    [SerializeField]
    Transform Target;

    [SerializeField]
    Transform[] Waypoints;
    int CurrWaypoint = 0;
    int speed = 5;
    float SwapDistance = 1;


    NavMeshAgent agent;
    Animator ani;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        Target = Waypoints[CurrWaypoint];
    }
	
	
	void Update ()
    {
        var rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        if (agent.remainingDistance <= SwapDistance + agent.stoppingDistance)
        {
            CurrWaypoint++;
            if (CurrWaypoint > Waypoints.Length - 1)
                CurrWaypoint = 0;
            Target = Waypoints[CurrWaypoint];
            //agent.Stop();
            //ani.SetTrigger("Pray");
            //agent.Resume();
            //transform.LookAt(Target);
            agent.SetDestination(Target.position);
        }       
        ani.SetFloat("Speed", agent.velocity.magnitude);
	}
}
