using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : PlayerMovement
{
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                hitObject = hit.transform.gameObject;
                Debug.Log("Clicked" + hit.transform.name);
            
        
                if (hit.transform.tag == "Tree")
                {
                     Debug.Log("Clicked tree");
                    target.GetComponent<TreeInfo>().ChopTree();
                }
            }
        }
    }
}
