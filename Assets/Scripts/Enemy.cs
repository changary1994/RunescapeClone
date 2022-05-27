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


    bool isAttacked = false;
    float hitCooldown = 1f;
    float canHit = 0f;
    const int MAX_HEALTH = 10;
    protected void Start()
    {
        
    }

    protected virtual void Init()
    {

    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if(isAttacked && Time.time > canHit)
        {
            health -= 1;
            canHit = Time.time + hitCooldown;
        }
        if (health == 0)
        {
            OnDeath();
        }
    }

    protected virtual void Move()
    {

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
