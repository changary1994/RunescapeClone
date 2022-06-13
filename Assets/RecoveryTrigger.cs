using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.RecoveryZoneEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.RecoveryZoneExit();
    }
}
