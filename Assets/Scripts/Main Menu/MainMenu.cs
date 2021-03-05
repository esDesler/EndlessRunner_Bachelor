using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string endlessRunner;

    public void PlayGame()
    {
        SceneManager.LoadScene(endlessRunner);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
