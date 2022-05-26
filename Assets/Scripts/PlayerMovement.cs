using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    protected Camera cam;
    public NavMeshAgent agent;
    [SerializeField] public Animator playerAnimator;
    [SerializeField] float objectDistance = 3f;
    protected GameObject hitObject;
    public bool hitting = false;
    bool playerHitting = false;
    const int IDLE = 0;
    const int RUN = 1;
    const int HIT = 2;
    Vector3 offsetAmount = new Vector3(0f, 1f, 0f);
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
            if (hit.transform.gameObject.tag == "Attackable")
            {
                Debug.Log(hit.transform.gameObject);
                var intObj = hit.transform.gameObject;
                StartCoroutine(MoveToInteraction(intObj));
            }
            else
            {
                agent.SetDestination(hit.point);
                Debug.Log(hit.transform.gameObject);
            }
        }
    }

    private IEnumerator MoveToInteraction(GameObject obj)
    {
        Debug.Log("Entered Coroutine");
        float distance = Vector3.Distance(this.transform.position, obj.transform.position);
        //finds location between the two object (.8f is a number between 0 - 1, 1 being the target, 0 being the object
        Vector3 newLine = obj.transform.position - this.transform.position;
        Vector3.Normalize(newLine);
        Vector3 newPosition = (this.transform.position + (.8f * newLine));
        agent.SetDestination(newPosition);
        //this makes sure to wait until object is close enough to target before continuing
        while (distance > objectDistance)
        {
            agent.SetDestination(newPosition);
            distance = Vector3.Distance(this.transform.position, obj.transform.position);
            yield return null;
        }
        Debug.Log("Close enough to target");
    }

    private void AttackEnemy()
    {

    }
}

