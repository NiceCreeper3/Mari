using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    #region
    // keaps trak if the game is paused or not
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    #endregion

    // Awaits player input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MariValues.MariIsDead)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Buttons methods
    #region
    // Pauses the game
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<AudioMangerScript>().PlayAudio("PauseMenuAudio", true);
    }

    //Resumes the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Reasets the game
    public void ReasetTheGame()
    {
        //Reasets score rikvaerments
        WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;

        WorldValues.PlayerSpawnPoint = new Vector3(0, 3, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    // goes the the main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MaiMenu");
        Time.timeScale = 1f;
    }

    // exits the game
    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
    #endregion
}
