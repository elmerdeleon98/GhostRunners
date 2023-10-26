using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static SceneSwitch instance;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    //Switches the scene depending on the scene's number
    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
