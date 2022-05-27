using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected int health;
    protected float speed;
    protected Vector3 movementDestination;
    [SerializeField] protected Transform player;
    protected Animator anim;



    bool isAttacked = false;
    float hitCooldown = 1f;
    float canHit = 0f;
    const int MAX_HEALTH = 10;
    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            Debug.LogError(transform.name + "Animator is NULL.");
        }
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        //if animation is idle and not in combat, then do not move this frame
       if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && !anim.GetBool("InCombat"))
        {
            return;
        }

        Move();
    }
    // TODO: continue movement AI
    protected virtual void Move()
    {
        //if not attacked, move to new position
        if (!isAttacked)
        {
            transform.position = Vector3.MoveTowards(transform.position, movementDestination, speed * Time.deltaTime);
        }
        //if player moves out of range, stop combat
        if (Vector3.Distance(player.position, transform.position) > 2f)
        {
            isAttacked = false;
            anim.SetBool("InCombat", false);
        }
    }

    protected virtual void Attack()
    {

    }

    

    protected virtual void Reset()
    {
        health = MAX_HEALTH;
    }
    protected virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
