using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : PlayerMovement
{
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetMouseButtonDown(0))
         {
             Ray ray = cam.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out RaycastHit hit))
             {
                 if (hit.transform.tag == "Tree")
                 {


                     target = hitInfo.transform.gameObject;
                     agent.SetDestination(hit.point);
                     target.GetComponent<TreeInfo>().ChopTree();
                 }
             }
         }*/
        if (hitObject.transform.tag == "Tree")
        {

            target.GetComponent<TreeInfo>().ChopTree();
        }
    }
}
