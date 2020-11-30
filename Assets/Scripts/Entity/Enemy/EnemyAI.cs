using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent Agent;

    [SerializeField] Transform target;

    [SerializeField] float distThreshold = 10f;

    [SerializeField] enum AIState {Idle, Chaising};

    [SerializeField] AIState aiState = AIState.Idle;

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
                    }
                    Agent.SetDestination(transform.position);
                    break;
                case AIState.Chaising:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distThreshold)
                    {
                        aiState = AIState.Idle; 
                    }
                    Agent.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
