using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJump : MonoBehaviour
{
    [SerializeField] private Renderer myObject;
    private bool isTranslucent = false;
    private bool isBlocked = false;

    // Update is called once per frame
    void Update()
    {
        //If Q is pressed and the player isn't blocked, it will activare the translucent state

        if (isBlocked == false)
        {
            if (Input.GetKey("q") && isTranslucent == false)
            {
                isTranslucent = true;
            }
        }
        
        //if translucent is on, then change the color of the player and start the countdown
        if (isTranslucent==true)
        {
            myObject.material.color = Color.magenta;
            StartCoroutine(GhostTimer());
        }

        //is the player is blocked, it will wait 10 secs
        if (isBlocked == true)
        {
            StartCoroutine(CoolDown());
        }
    }
    //will wait 5 secs before turning off translucent state, change the color back, start cool down
    public IEnumerator GhostTimer()
    {
        yield return new WaitForSeconds(5f);
        myObject.material.color = Color.grey;
        isTranslucent = false;
        isBlocked = true;

    }
    //will wait 10 secs before unblocking
    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(10f);
        isBlocked = false;
    }

}
