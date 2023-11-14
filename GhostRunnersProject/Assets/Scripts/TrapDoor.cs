using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public Renderer doorRenderer; // Reference to the Renderer component of the door
    public Collider doorCollider; // Reference to the Collider component of the door
    public Color blockingColor = Color.red; // Color when blocking players
    public Color passThroughColor = Color.green; // Color when allowing players to pass through
    public float blockDuration = 2.0f; // Duration the door is blocking players
    public float openDuration = 1.0f; // Duration the door is open for players to pass through

    private void Start()
    {
        StartCoroutine(ActivateColorDoorPeriodically());
    }

    private IEnumerator ActivateColorDoorPeriodically()
    {
        while (true)
        {
            //block players (change color and become transparent)
            SetDoorColor(blockingColor);
            SetDoorAlpha(0.5f); 
            doorCollider.enabled = true;
            yield return new WaitForSeconds(blockDuration);

            //allow players to pass through
            SetDoorColor(passThroughColor);
            SetDoorAlpha(1f);
            doorCollider.enabled = false;
            yield return new WaitForSeconds(openDuration);
        }
    }

    private void SetDoorColor(Color color)
    {
        doorRenderer.material.color = color;
    }

    private void SetDoorAlpha(float alpha)
    {
        Color currentColor = doorRenderer.material.color;
        currentColor.a = alpha;
        doorRenderer.material.color = currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doorRenderer.material.color == passThroughColor)
        {
            // Allow the player to pass through the door by disabling the collider
            doorCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Re-enable the collider when the player exits the trigger
            doorCollider.enabled = true;
        }
    }
}
