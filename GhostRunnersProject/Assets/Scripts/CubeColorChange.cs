using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorChange : MonoBehaviour
{
    public Material greenMaterial; // Assign a green material to this in the Unity Editor

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer cubeRenderer = GetComponent<Renderer>();

            if (cubeRenderer != null && greenMaterial != null)
            {
                cubeRenderer.material = greenMaterial;
            }
            else
            {
                Debug.LogWarning("Cube renderer or green material is not assigned.");
            }
        }
    }
}
