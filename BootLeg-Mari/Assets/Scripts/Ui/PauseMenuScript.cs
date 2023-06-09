using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    #region
    // keaps trak if the game is paused or not
    public static bool GaemIsPaused = false;
    public GameObject pauseMenuUI;
    #endregion

    // Awaits player input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GaemIsPaused)
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
        GaemIsPaused = true;
    }

    //Resumes the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GaemIsPaused = false;
    }

    // Reasets the game
    public void ReasetTheGame()
    {
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
