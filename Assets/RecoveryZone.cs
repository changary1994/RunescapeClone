using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryZone : MonoBehaviour
{
    // Start is called before the first frame update
    Color colorStart = Color.red;
    Color colorEnd = Color.green;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colorStart;
        GameEvents.current.onRecoveryZoneTriggerEnter += OnRecoveryZoneEntry;
        GameEvents.current.onRecoveryZoneTriggerExit += OnRecoveryZoneExit;
    }

    // Update is called once per frame
    private void OnRecoveryZoneEntry()
    {
        rend.material.color = colorEnd;
    }

    private void OnRecoveryZoneExit()
    {
        rend.material.color = colorStart;
    }

    private void OnDisable()
    {
        GameEvents.current.onRecoveryZoneTriggerEnter -= OnRecoveryZoneEntry;
        GameEvents.current.onRecoveryZoneTriggerExit -= OnRecoveryZoneExit;
    }
}
