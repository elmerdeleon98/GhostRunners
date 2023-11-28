using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public string correctCode = "123"; //correct code
    public InputField codeInputField;
    public GameObject door;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && IsPlayerNearDoor())
        {
            AttemptToUnlockDoor();
        }
    }

    bool IsPlayerNearDoor()
    {
        return true;
    }

    void AttemptToUnlockDoor()
    {
        string enteredCode = codeInputField.text;

        if (enteredCode.Length == 3 && enteredCode == correctCode)
        {
            Debug.Log("Door Unlocked!!!");
            OpenDoor();
        }
        else
        {
            Debug.Log("Incorrect Code. Try again!");
            
        }
    }

    void OpenDoor()
    {
        door.SetActive(false);
    }
}
