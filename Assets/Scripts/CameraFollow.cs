using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    //Set target for camera to follow
    private Transform target;
    [SerializeField]
    //Set height distance (y axis);
    private float height = 2.0f;
    [SerializeField]
    //Set offset distance (z axis);
    private float offset = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Late update runs after update
    private void LateUpdate()
    {
        //If there's no target, don't follow
        if (!target)
            return;
        //Actual camera height should be the target + height desired, assign to this variable
        float wantedHeight = target.position.y + height;
        //Actual camera offset should be the target + offset desired, assign to this variable
        float wantedOffset = target.position.z - offset;
        //Move the camera position to where the player is
        transform.position = target.position;
        //Now change the position to a new position based on the wanted variables set earlier
        transform.position = new Vector3(transform.position.x, wantedHeight, wantedOffset);
        //Lookat method forces the camera rotation to face towards the target object
        transform.LookAt(target);
        //Rotate this camera to this new Vector3 to achieve angled perspective
        transform.rotation = Quaternion.Euler(67, 0f, 0f);
    }
}
