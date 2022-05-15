using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    protected Camera cam;
    protected NavMeshAgent agent;
    [SerializeField] public Animator playerAnimator;
    protected GameObject hitObject;
    public bool cancel = false;
    public bool hitting = false;
    bool playerHitting = false;
    const int IDLE = 0;
    const int RUN = 1;
    const int HIT = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        playerAnimator.SetInteger("state", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        cancel = false;
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }
        playerHitting = hitting;

        if (playerHitting == true)
        {
            playerAnimator.SetBool("hitting", true);
        }
        if (playerHitting == false)
        {
            playerAnimator.SetBool("hitting", false);
        }
        
        if (agent.velocity != Vector3.zero)
        {
            playerAnimator.SetInteger("state", RUN);
        }
        
        if (agent.velocity == Vector3.zero)
            playerAnimator.SetInteger("state", IDLE);
    
    }
        

    

    void MovePlayer()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
            cancel = true;
        }
    }
}

