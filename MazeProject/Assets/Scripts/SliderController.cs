using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Action<float> SlideValueChange;

    void Start()
    {
        Slider slider = gameObject.GetComponent<Slider>();

        slider.wholeNumbers = true;
        slider.minValue = 3;
        slider.maxValue = 51;
        
        slider.onValueChanged.AddListener(SlideChange);
    }

    void SlideChange(float value)
    {
        if (value % 2 == 0)
            value++;

        if (SlideValueChange != null)
            SlideValueChange.Invoke(value);
    }
}
