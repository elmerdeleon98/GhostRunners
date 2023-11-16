using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public Renderer doorRenderer;
    public Collider doorCollider;
    public Color redColor = Color.red; //red color door
    public float disappearDuration = 2f; //timer for door

    private void Start()
    {
        StartCoroutine(ChangeColorAndDisappear());
    }

    private IEnumerator ChangeColorAndDisappear()
    {
        while (true)
        {
            //changes door color to red
            SetDoorColor(redColor);

            yield return new WaitForSeconds(disappearDuration);

            doorRenderer.enabled = false;
            doorCollider.enabled = false;

            yield return new WaitForSeconds(disappearDuration);

            doorRenderer.enabled = true;
            doorCollider.enabled = true;
        }
    }

    private void SetDoorColor(Color color)
    {
        doorRenderer.material.color = color;
    }
}
