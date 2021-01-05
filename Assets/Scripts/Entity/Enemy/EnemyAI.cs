using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    private const float attackCooldown = 1;



    [SerializeField] private float distanceThreshold = 10f;
    [SerializeField] private float attackThreshold = 1.5f; 

    [SerializeField] private AIState state = AIState.Idle;

    private NavMeshAgent agent;

    [SerializeField] private Transform target;

    private Animator animator;

    //=====

    [SerializeField] private uint dmg;

    private float lastAttackTime = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(States());
    }

    private void Update()
    {
        //Debug.Log(lastAttackTime);
        //Debug.Log(attackCooldown);

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

                        //if (lastAttackTime < attackCooldown)
                        //{
                        //    animator.SetBool("Attack", true);
                        //}
                    }
                    agent.SetDestination(target.position);
                    break;
                case AIState.Attacking:
                    Debug.Log("Attack");
                    if (Time.time - lastAttackTime > attackCooldown)
                    {
                        lastAttackTime = Time.time;
                        target.GetComponent<Health>().Reduce(dmg);
                    }
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
