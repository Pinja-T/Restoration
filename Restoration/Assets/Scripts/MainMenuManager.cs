using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //Loads the game on button press
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();

        //Quits game when in unity editor
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
    }
}
