using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Animator tr;
    AudioSource click;
    private void Start()
    {
        click = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //Loads the game on button press
    public void StartGame()
    {
        if (!click.isPlaying) click.Play();
        StartCoroutine(Transition("Play"));
    }

    //Quits the game
    public void QuitGame()
    {
        if(!click.isPlaying) click.Play();
        StartCoroutine(Transition("Quit"));
    }
    IEnumerator Transition(string op)
    {
        tr.SetTrigger("Transition");
        yield return new WaitForSeconds(1);
        switch (op)
        {
            case "Quit":
                Application.Quit();

                //Quits game when in unity editor
                #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
                #endif
                break;
            case "Play":
                SceneManager.LoadScene("Game");
                break;
            default:
                break;
        }
    }
}
