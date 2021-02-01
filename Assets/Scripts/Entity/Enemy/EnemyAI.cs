using DesertStormZombies.Entity;
using DesertStormZombies.Utility;

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private uint damage;

    [SerializeField] private float distanceThreshold = 10f;
    [SerializeField] private float attackThreshold = 1.5f;

    [SerializeField] private AIState state = AIState.Idle;

    [SerializeField] private Transform target;

    [SerializeField] private ParticleSystem explodeParticle;
    [SerializeField] private ParticleSystem bloodParticle;

    private const float AttackCooldown = 1;

    private float lastAttackTime = 0;

    private Animator animator;

    private IntervalTimer intervalTimer;

    private NavMeshAgent agent;

    public ParticleSystem ExplodeParticle => explodeParticle;
    public ParticleSystem BloodParticle => bloodParticle;

    enum AIState
    {
        Idle,
        Chaising,
        Attacking,
        Death
    };

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        intervalTimer = new IntervalTimer(0.2f);
    }

    private void Update()
    {
        if(intervalTimer.Check(Time.deltaTime))
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
                    dist = Vector3.Distance(target.position, transform.position);

                    if (Time.time - lastAttackTime > AttackCooldown)
                    {
                        lastAttackTime = Time.time;
                        target.GetComponent<Health>().Reduce(damage);
                    }

                    agent.SetDestination(transform.position);

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
        }

    }

    public void setTarget(PlayerMovement player) => target = player.transform;

}
