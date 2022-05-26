using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralObject : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 10;
    bool isAttacked = false;
    float hitCooldown = 1f;
    float canHit = 0f;
    const int MAX_HEALTH = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    void Damage()
    {
        isAttacked = true;
    }

    void StopDamage()
    {
        isAttacked = false;
    }

    private void Reset()
    {
        health = MAX_HEALTH;
    }
    private void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
