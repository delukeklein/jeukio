using FPSControllerLPFP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float distanceThreshold = 10f;
    [SerializeField] private float attackThreshold = 1.5f; 

    [SerializeField] private AIState state = AIState.Idle;

    private NavMeshAgent agent;

    private Transform target;

    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(States());
    }

    private void Update()
    {
        
    }

    IEnumerator States()
    {
        while (true)
        {
            switch (state)
            {
                case AIState.Idle:
                    float dist = Vector3.Distance(target.position, transform.position);

                    if (dist < distanceThreshold)
                    {
                        state = AIState.Chaising;
                        animator.SetBool("Chaising", true);
                    }
                    agent.SetDestination(transform.position);
                    break;
                case AIState.Chaising:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distanceThreshold)
                    {
                        state = AIState.Idle;
                        animator.SetBool("Chaising", false);

                    }
                    if (dist < attackThreshold)
                    {
                        state = AIState.Attacking;
                        animator.SetBool("Attack", true);


                    }
                    agent.SetDestination(target.position);
                    break;
                case AIState.Attacking:
                    Debug.Log("Attack");
                    agent.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > attackThreshold)
                    {
                        state = AIState.Chaising;
                        animator.SetBool("Attack", false);

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

    public void setTarget(FpsControllerLPFP playerController) => target = playerController.transform;

    enum AIState
    {
        Idle,
        Chaising,
        Attacking,
        Death
    };

}
