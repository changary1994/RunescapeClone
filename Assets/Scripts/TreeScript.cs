using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : Interactable
{
    [SerializeField] private int treeHealth = 5;
    bool isBeingChopped = false;
    bool inTreeTrigger = false;
    int maxCount = 1;
    int count = 0;
    [SerializeField] GameObject uiController;
    [SerializeField] GameObject player;
    public WoodInventoryItem wood;
    [SerializeField] PlayerEquipmentController equipmentController;
   

    void Start()
    {
        uiController = GameObject.Find("UIController");
        player = GameObject.Find("Player");
        equipmentController = GameObject.Find("Player").GetComponent<PlayerEquipmentController>();
    }

    void Update()
    {
        if (inTreeTrigger && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(CoChopTree());
            uiController.GetComponent<UIController>().hideInteraction();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            inTreeTrigger = true;
            uiController.GetComponent<UIController>().showInteraction();
            this.GetComponent<Outlines>().OutlineWidth = 10f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTreeTrigger = false;
            uiController.GetComponent<UIController>().hideInteraction();
            this.GetComponent<Outlines>().OutlineWidth = 0f;
        }
    }

    
    public override void Interact()
    {
        Debug.Log("Interacting with Tree.");
    }

    public override void Interrupt() //resets tree to full health and all UI components reset
    {
        Debug.Log("Interrupted");
        treeHealth = 5;
        player.GetComponent<PlayerMovement>().hitting = false;
        GameObject.Find("InteractSlider").GetComponent<FillBar>().resetBar = true;
        uiController.GetComponent<UIController>().hideProgressBar();
        isBeingChopped = false;
        count--;
    } 

    
    private IEnumerator CoChopTree()
    {

        isBeingChopped = true;
        if(count >= maxCount) // this makes sure that this coroutine only happens once per tree.
                yield break; // if this was called more than once, break from the extra coroutine
        count++;
        uiController.GetComponent<UIController>().showProgressBar();  
        WaitForSeconds waitTime = new WaitForSeconds(1f); //create a wait timer to delay tree chopping
        player.GetComponent<PlayerMovement>().hitting = true; //set player animation to "hitting"
        while (treeHealth > 0 && isBeingChopped == true)
        {
            if (player.GetComponent<PlayerMovement>().agent.velocity != Vector3.zero) //ensures player is not moving (channelling)
            {
                Interrupt(); //if player moves, interrupt action
                yield break;
            }
            player.GetComponent<PlayerMovement>().transform.LookAt(this.transform); //make player continue to face tree
            GameObject.Find("InteractSlider").GetComponent<FillBar>().CurrentValue += .2f; 
            treeHealth = treeHealth - 1;
            Debug.Log(treeHealth);
            yield return waitTime; //channel time for coroutine
        }
        player.GetComponent<PlayerMovement>().hitting = false; //turn off animation for hitting, once complete
        wood.AssignItemToPlayer(equipmentController); //assign a wood item to player
        isBeingChopped = false; 
        Debug.Log("Stopping"); 
        count--; // change this variable back to 0 so we can do this routine again now that it is done.
        GameObject.Find("InteractSlider").GetComponent<FillBar>().resetBar = true;
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().storeSpawnSpot(this.transform.position); //store this position into spawn manager so spawn manager can replace tree with stump until this tree respawns 
        uiController.GetComponent<UIController>().hideProgressBar();
        Destroy(this.gameObject, 1f);
    }
}