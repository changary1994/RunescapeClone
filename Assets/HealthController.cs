using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    private int health;

    const int MAX_HEALTH = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = 50; //to test recovery zone
        GameEvents.current.onRecoveryZoneTriggerEnter += OnRecoveryZoneEntry;
        GameEvents.current.onRecoveryZoneTriggerExit += OnRecoveryZoneExit;
    }

    // Update is called once per frame
    private void OnRecoveryZoneEntry()
    {
        InvokeRepeating("RecoveryZoneHeal", 0f, .2f);
        Debug.Log("Entered Recovery zone, health is "+ health);
    }

    private void OnRecoveryZoneExit()
    {
        CancelInvoke();
        Debug.Log("Exited Recovery zone, health is " + health);
    }

    void RecoveryZoneHeal()
    {
        if(health < MAX_HEALTH)
        {
            health += 1;
        }
        if(health == MAX_HEALTH)
        {
            CancelInvoke();
        }
        Debug.Log("Health = " + health);
    }
}
