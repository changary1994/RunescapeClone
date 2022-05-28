using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected int health;
    protected float speed = 10;
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
    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        //anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        startPosition = this.transform.position;
        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(this.transform.position, out closestHit, 500f, NavMesh.AllAreas))
            this.transform.position = closestHit.position;
        //if (anim == null)
        //{
        //   Debug.LogError(transform.name + "Animator is NULL.");
        //}

        InvokeRepeating("Move", 1f, 5f);
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        //if animation is idle and not in combat, then do not move this frame
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && !anim.GetBool("InCombat"))
        //{
        //   return;
        //}  
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
