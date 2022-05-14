using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ActiveWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform _rightHand;
    [SerializeField]
    private GameObject _activeWeapon;
    private bool _gameRunning = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (_activeWeapon != null && _gameRunning == false)
        {
            _activeWeapon.transform.parent = _rightHand;
            _activeWeapon.transform.localPosition = Vector3.zero;
        }
            
	}


}
