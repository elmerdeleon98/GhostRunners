using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShade : MonoBehaviour
{
    [SerializeField] private Renderer checkPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPoint.material.color = Color.yellow;
        }
    }
}
