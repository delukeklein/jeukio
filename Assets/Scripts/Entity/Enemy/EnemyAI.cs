using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent Agent;

    [SerializeField] Transform target;

    [SerializeField] float distThreshold = 10f;
    [SerializeField] float AttThreshold = 1.5f; 

     [SerializeField] enum AIState {Idle, Chaising, Attacking, Death};

    [SerializeField] AIState aiState = AIState.Idle;

    [SerializeField] Animator anim;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        StartCoroutine(States());

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    IEnumerator States()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIState.Idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < distThreshold)
                    {
                        aiState = AIState.Chaising;
                        anim.SetBool("Chaising", true);
                    }
                    Agent.SetDestination(transform.position);
                    break;
                case AIState.Chaising:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distThreshold)
                    {
                        aiState = AIState.Idle;
                        anim.SetBool("Chaising", false);

                    }
                    if (dist < AttThreshold)
                    {
                        aiState = AIState.Attacking;
                        anim.SetBool("Attack", true);


                    }
                    Agent.SetDestination(target.position);
                    break;
                case AIState.Attacking:
                    Debug.Log("Attack");
                    Agent.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > AttThreshold)
                    {
                        aiState = AIState.Chaising;
                        anim.SetBool("Attack", false);

                    }
                    break;
                case AIState.Death:
                    break;
                //case AIState.Walking:
                //    break;
                //case AIState.Running:
                //    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
