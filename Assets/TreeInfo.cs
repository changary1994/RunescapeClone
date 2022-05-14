using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo : MonoBehaviour
{
    [SerializeField] private int treeHealth = 5;
    bool isBeingChopped = false;
    bool interrupt = false;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
    
        if (treeHealth == 0)
        {
            Destroy(this.gameObject);
        }
        interrupt = GameObject.Find("Player").GetComponent<PlayerMovement>().cancel;
        if (interrupt == true)
            {
                Debug.Log("Cancelling");
                StopAllCoroutines();
                
            }
    }

    public void ChopTree()
    {
        StartCoroutine(CoChopTree());
    }

    private IEnumerator CoChopTree()
    {
        
        isBeingChopped = true;
        while (treeHealth > 0 && isBeingChopped == true)
        {

            treeHealth = treeHealth - 1;
            Debug.Log(treeHealth);
            yield return new WaitForSeconds(1f);
        }
        isBeingChopped = false;
    }
}
