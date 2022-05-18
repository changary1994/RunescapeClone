using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    GameObject[] interactSlider;
    GameObject[] interactText;
    // Start is called before the first frame update
    void Start()
    {
        interactSlider = GameObject.FindGameObjectsWithTag("InteractBar");
        interactText = GameObject.FindGameObjectsWithTag("InteractText");
        foreach (GameObject g in interactSlider)
            g.SetActive(false);
        foreach (GameObject g in interactText)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showProgressBar(){
        foreach (GameObject g in interactSlider)
        g.SetActive(true);
    }

    public void hideProgressBar(){
        foreach (GameObject g in interactSlider)
        g.SetActive(false);
    }

    public void showInteraction(){
        foreach (GameObject g in interactText)
        g.SetActive(true);
    }

    public void hideInteraction(){
        foreach (GameObject g in interactText)
        g.SetActive(false);
    }

}
