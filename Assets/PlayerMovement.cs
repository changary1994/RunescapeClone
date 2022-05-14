using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    protected Camera cam;
    protected NavMeshAgent agent;
    [SerializeField] Animator animator;
    protected GameObject hitObject;

    const int IDLE = 0;
    const int RUN = 1;
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                hitObject = hit.transform.gameObject;
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
