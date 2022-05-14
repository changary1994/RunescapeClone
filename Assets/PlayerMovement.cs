using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    protected Camera cam;
    protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    protected GameObject hitObject;
    public bool cancel = false;
    const int IDLE = 0;
    const int RUN = 1;
    string objectTag = "s";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator.SetInteger("state", IDLE);
        
    }

    // Update is called once per frame
    void Update()
    {
        cancel = false;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                hitObject = hit.transform.gameObject;
                float distance = Vector3.Distance(agent.transform.position, hitObject.transform.position);
                Debug.Log("Clicked" + hit.transform.name);
                objectTag = hit.transform.tag;
                if (distance < 3)
                {
                    switch (objectTag)
                        {
                            case "Tree":
                                Debug.Log("Chopping Tree");
                                hitObject.GetComponent<TreeInfo>().ChopTree();
                                break;
                            default:
                                Debug.Log("Cancel");
                                cancel = true;
                                break;
                        }
                }
                else cancel = true;
            }
            
        }
        
        
        if (agent.velocity != Vector3.zero)
        {
            animator.SetInteger("state", RUN);
        }
        else
            animator.SetInteger("state", IDLE);
    }
}

