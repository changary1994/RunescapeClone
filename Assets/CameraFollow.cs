using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float height = 2.0f;
    [SerializeField]
    private float offset = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void LateUpdate()
    {
        if (!target)
            return;

        float wantedHeight = target.position.y + height;
        float wantedOffset = target.position.z - offset;
        transform.position = target.position;
        transform.position = new Vector3(transform.position.x, wantedHeight, wantedOffset);
        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(67, 0f, 0f);
    }
}
