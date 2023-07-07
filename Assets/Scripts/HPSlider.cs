using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HPSlider : MonoBehaviour
{
    // HPSlider Values
    public Slider hpSlider;

    public void InitBar(float maxValue)
    {
        hpSlider.maxValue = maxValue;
        hpSlider.value = maxValue;
    }

    public void SetValue(float hpvalue)
    {
        hpSlider.value = hpvalue;
    }
}