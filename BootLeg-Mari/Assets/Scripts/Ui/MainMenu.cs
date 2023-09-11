using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {


        WorldValues.PlayerSpawnPoint = new Vector3(0, 3, 0);
        SceneManager.LoadScene("MariMap");
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
}
