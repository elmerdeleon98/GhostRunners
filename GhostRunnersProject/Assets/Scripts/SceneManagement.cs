using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int gameSceneIndex; 

    void Start()
    {
        // Loads the last valid gameplay scene 
        gameSceneIndex = PlayerPrefs.GetInt("LastGameplayScene", 0);
    }

    void Update()
    {
        if (Player.playerHealth <= 0)
        {
            // If the current scene is not the game over scene, store it as the last gameplay scene
            if (SceneManager.GetActiveScene().buildIndex != 7)
            {
                gameSceneIndex = SceneManager.GetActiveScene().buildIndex;
                // Save the last valid gameplay scene index to PlayerPrefs
                PlayerPrefs.SetInt("LastGameplayScene", gameSceneIndex);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(7);
            Player.playerHealth = 10;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void appClose()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStartScene()
    {
        // Restarts the last valid gameplay scene
        SceneManager.LoadScene(gameSceneIndex); 
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;   
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(1);
    }
}
