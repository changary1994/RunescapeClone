using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected int health;
    [SerializeField] protected Transform player;
    protected Animator anim;
    protected NavMeshAgent agent;



    bool isAttacked = false;
    float hitCooldown = 1f;
    float canHit = 0f;
    protected const int MAX_HEALTH = 10;

    protected Vector3 movementDestination;
    protected Vector3 startPosition;
    protected float wanderRange = 5f;
    private bool wandering = true;
    private bool chasing = true;
    private bool isIdle = false;

    protected const int WALK = 4;
    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        startPosition = this.transform.position;
        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(this.transform.position, out closestHit, 500f, NavMesh.AllAreas))
            this.transform.position = closestHit.position;
        if (anim == null)
        {
           Debug.LogError(transform.name + "Animator is NULL.");
        }

        InvokeRepeating("Move", 1f, 8f);
    }
 
    protected virtual void Update()
    {
        //if animation is idle and not in combat, then do not move this frame
        isIdle = CheckIdle();
      

        if (agent.velocity == Vector3.zero)
        {
            anim.SetInteger("state", Random.Range(0,3));
        }
    }

    protected virtual bool CheckIdle()
    {
        bool idle;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Idle2") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Idle3") || anim.GetCurrentAnimatorStateInfo(0).IsName("Idle4"))
        {
            idle = true;
        }
        else
        {
            idle = false;
        }
        return idle;
    }
    protected virtual void Move()
    {
        Debug.Log("Called Move");
        movementDestination = FindNewPosition();
        //if not attacked, move to new position
        if (!isAttacked)
        {
            agent.SetDestination(movementDestination);
            Debug.Log("Attempted to move agent to " + movementDestination);
            anim.SetInteger("state", WALK);
        }



        //if player moves out of range, stop combat
        if (Vector3.Distance(player.position, transform.position) > 2f)
        {
            isAttacked = false;
          //  anim.SetBool("InCombat", false);
        }
    }

    protected virtual Vector3 FindNewPosition()
    {
        //Wander by using the start position as base, and adding a max wander range in respective coordinates, return that new vector3 as a new position
        Vector3 newPosition = startPosition + new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        return newPosition;
    }

    protected virtual void Attack()
    {

    }

    

    protected virtual void Reset()
    {
        health = MAX_HEALTH;
        agent.SetDestination(startPosition);
    }
    protected virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
