using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJump : MonoBehaviour
{
    [SerializeField] private Renderer myObject;
    public bool isTranslucent = false;
    public bool isBlocked = false;

    public GhostTimer ghostTimer;

    private void Start()
    {
        // Initialize the GhostTimer
        ghostTimer.MaxDuration(5f);
    }

    void Update()
    {
        // If Q is pressed and the player isn't blocked, it will activate the translucent state
        if (isBlocked == false)
        {
            if (Input.GetKey("q") && isTranslucent == false)
            {
                isTranslucent = true;
                StartCoroutine(GhostTimerCountdown());
            }
        }

        // If translucent is on, then change the color of the player
        if (isTranslucent == true)
        {
            myObject.material.color = Color.magenta;
            ghostTimer.SetDuration(ghostTimer.ghostSlider.value - Time.deltaTime);
        }

        if (isTranslucent == false && isBlocked == true)
        {
            ghostTimer.SetDuration(ghostTimer.ghostSlider.value + Time.deltaTime);
        }

        // If the player is blocked, it will wait 10 seconds
        if (isBlocked == true)
        {
            StartCoroutine(CoolDown());
        }
    }

    // Will wait 5 seconds before turning off translucent state, change the color back, start cool down
    public IEnumerator GhostTimerCountdown()
    {
        yield return new WaitForSeconds(5f);
        myObject.material.color = Color.grey;
        isTranslucent = false;
        isBlocked = true;
    }

    // Will wait 10 seconds before unblocking
    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5f);
        isBlocked = false;
    }
}
