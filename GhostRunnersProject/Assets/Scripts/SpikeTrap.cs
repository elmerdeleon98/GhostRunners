using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Transform spikes; // Reference to the spikes transform
    public float moveDistance = 1.0f; // Adjust this value for the distance the spikes should move on the Y-axis
    public float moveSpeed = 4.0f; // Adjust this value for the speed of the spike movement
    public Vector3[] targetPositions; // Specify target positions in the Inspector for each trap

    private bool isRising = false;
    private int currentTargetIndex = 0;

    private void Start()
    {
        StartCoroutine(MoveSpikesPeriodically());
    }

    private IEnumerator MoveSpikesPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); //adjusts the time for spikes

            isRising = !isRising; // Toggle the direction

            int nextTargetIndex = isRising ? (currentTargetIndex + 1) % targetPositions.Length : currentTargetIndex;
            Vector3 initialPosition = spikes.localPosition;
            Vector3 targetPosition = targetPositions[nextTargetIndex];
            float elapsedTime = 0;

            while (elapsedTime < 1f)
            {
                spikes.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime);
                elapsedTime += Time.deltaTime * moveSpeed;
                yield return null;
            }

            currentTargetIndex = nextTargetIndex;
        }
    }
}
