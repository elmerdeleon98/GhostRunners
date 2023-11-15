using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatBar : MonoBehaviour
{
    public Slider slider;

    public void MaxDuration(float duration)
    {
        slider.maxValue = duration;
        slider.value = duration;
    }

    public void SetDuration(float duration)
    {
        slider.value = duration;
    }
}
