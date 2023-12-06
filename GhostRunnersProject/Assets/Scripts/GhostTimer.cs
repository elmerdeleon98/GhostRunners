using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour
{
    public Slider ghostSlider;

    public void MaxDuration(float duration)
    {
        ghostSlider.maxValue = duration;
        ghostSlider.value = duration;
    }

    public void SetDuration(float duration)
    {
        ghostSlider.value = duration;
    }
}
