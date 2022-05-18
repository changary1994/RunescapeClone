using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TestTween : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 follow;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        follow = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        follow = player.transform.position;
        transform.DOMove(follow, 1);
    }
}
