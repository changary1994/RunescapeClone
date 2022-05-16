using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillBar : MonoBehaviour
{
    public Slider slider;
    //if I want to change text
    //public TMP_Text displayText;
    private float currentValue = 0f;
    public bool resetBar = false;

    public float CurrentValue {
        get {
            return currentValue;
        }
        set{
            currentValue = value;
            slider.value = currentValue;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (resetBar == true)
        {
            CurrentValue = 0f;
            resetBar = false;
        }
    }
}
