using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onRecoveryZoneTriggerEnter += OnRecoveryZoneEntry;
    }

    // Update is called once per frame
    private void OnRecoveryZoneEntry()
    {
        
    }
}
