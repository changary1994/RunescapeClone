using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    public event Action onRecoveryZoneTriggerEnter; //delegate for when entering a recovery zone

    public void RecoveryZoneEnter()
    {
        if (onRecoveryZoneTriggerEnter != null)
        {
            onRecoveryZoneTriggerEnter();
        }
    }
}
