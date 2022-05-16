using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject tree;
    public Vector3 spawnSpot;
    [SerializeField] GameObject stump;

    public bool toRespawn = false;
    public float respawnRate = 10f;
    private float canRespawn = 0f;
    const int NUM_TREES = 10;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (toRespawn == true && Time.time > canRespawn)
        {
            respawnTree();
            toRespawn = false;
        }
    }

    public void storeSpawnSpot(Vector3 loc)
    {
        spawnSpot = loc;
        canRespawn = respawnRate + Time.time;
        //assign object to instantiate to variable so it can be destroyed later
        GameObject tempStump = (GameObject)Instantiate (stump, spawnSpot, Quaternion.identity);
        Destroy(tempStump, respawnRate);
    }

    public void respawnTree()
    {
        Instantiate(tree, spawnSpot, Quaternion.identity);
    }

    // void spawnTree()
    // {
    //     float xMin = -8f;
    //     float xMax = 8f;
    //     float zMin = -8f;
    //     float zMax = 8f;
    //     float y = -4.479344f;

    //     for (int i = 0; i < NUM_TREES; i++){
    //         Vector3 position = new Vector3(Random.Range(xMin, xMax), y, Random.Range(zMin, zMax));
    //         Instantiate(tree, position, Quaternion.identity);
    //     }
    // }

}
