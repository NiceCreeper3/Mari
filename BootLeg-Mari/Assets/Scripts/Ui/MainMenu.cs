using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MariMap");
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
}
