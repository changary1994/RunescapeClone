using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : Enemy
{
    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        base.Update();
    }
    // Update is called once per fram

    protected override void Move()
    {
        base.Move();
    }

    protected override Vector3 FindNewPosition()
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
