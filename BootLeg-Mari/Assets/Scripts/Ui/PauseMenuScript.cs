using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    #region
    // keaps trak if the game is paused or not
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private CommenUIElements commenUI;
    #endregion

    private void Start()
    {
        commenUI = GetComponent<CommenUIElements>();
    }

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
        // sets the PauseUI activate and stopes time 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // playse audio to indekat the player has paused the game
        FindObjectOfType<AudioMangerScript>().PlayAudio("PauseMenuAudio", true);
    }

    //Resumes the game
    public void ResumeGame()
    {
        //Removes the pause menu and unpauses time
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ReasetTheScene()
    {
        // reasets states
        CommenUIElements.ReasetGameStates();

        // realoads the scene and unpauses time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    // goes the the main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MaiMenu");
        //Reasts the games states
        CommenUIElements.ReasetGameStates();
        Time.timeScale = 1f;
    }

    #endregion
}
