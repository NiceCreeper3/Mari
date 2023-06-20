using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        //Reasets score rikvaerments
        WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;

        WorldValues.PlayerSpawnPoint = new Vector3(0, 3, 0);
        SceneManager.LoadScene("MariMap");
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
}
