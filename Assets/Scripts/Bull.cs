using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : Enemy
{

    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        base.Update();
    }
    // Update is called once per fram

    protected override bool CheckIdle()
    {
        return base.CheckIdle();
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override Vector3 FindNewPosition()
    {
        return base.FindNewPosition();
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
