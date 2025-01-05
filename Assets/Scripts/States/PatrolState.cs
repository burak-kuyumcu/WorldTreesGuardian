using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolState : StateMachineBehaviour
{
    float timer = 0;
    NavMeshAgent agent;
    List<Transform> wayPoints = new List<Transform>();

    Transform player;
    float agroRange = 7f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        agent = animator.GetComponent<NavMeshAgent>();
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach(Transform item in go.transform)
        {
            wayPoints.Add(item);
        }

        agent.SetDestination(wayPoints[Random.Range(0,wayPoints.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = 1.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        timer += Time.deltaTime;
        if(timer > 6)
        {
            animator.SetBool("isPatrolling", false);
        }

        float distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance < agroRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}



