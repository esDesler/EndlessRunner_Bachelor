using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;

    public GameObject thePauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
