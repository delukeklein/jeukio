using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent Agent;

    [SerializeField] Transform target;

    [SerializeField] enum AIState {Idle, Chaising};

    [SerializeField] AIState aiState = AIState.Idle;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        StartCoroutine(States());

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
                    break;
                case AIState.Chaising:
                    Agent.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
