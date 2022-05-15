using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : Interactable
{
    [SerializeField] private int treeHealth = 5;
    bool isBeingChopped = false;
    bool interrupt = false;
    bool inTreeTrigger = false;
    [SerializeField] GameObject uiController;
    void Start()
    {
        uiController = GameObject.Find("UIController");
    }

    void Update()
    {
        if (inTreeTrigger = true && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(CoChopTree());
            uiController.GetComponent<UIController>().hideInteraction();
        }

        interrupt = GameObject.Find("Player").GetComponent<PlayerMovement>().cancel;
        if (interrupt == true)
        {
            Interrupt();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTreeTrigger = true;
            uiController.GetComponent<UIController>().showInteraction();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTreeTrigger = false;
            uiController.GetComponent<UIController>().hideInteraction();
        }
    }

    public override void Interact()
    {
        Debug.Log("Interacting with Tree.");
    }

    public override void Interrupt()
    {
            Debug.Log("Interrupted");
            StopAllCoroutines();
            treeHealth = 5;
            interrupt = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().hitting = false;
    }
    public void ChopTree()
    {
        StartCoroutine(CoChopTree());
    }
    private IEnumerator CoChopTree()
    {

        isBeingChopped = true;
        uiController.GetComponent<UIController>().showProgressBar();
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().hitting = true;
        while (treeHealth > 0 && isBeingChopped == true)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().transform.LookAt(this.transform);
            GameObject.Find("InteractSlider").GetComponent<FillBar>().CurrentValue += .2f;
            treeHealth = treeHealth - 1;
            Debug.Log(treeHealth);
            yield return waitTime;
        }
        GameObject.Find("Player").GetComponent<PlayerMovement>().hitting = false;
        isBeingChopped = false;
        Debug.Log("Stopping"); 
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().storeSpawnSpot(this.transform.position);  
        uiController.GetComponent<UIController>().hideProgressBar(); 
        Destroy(this.gameObject);
    }
}