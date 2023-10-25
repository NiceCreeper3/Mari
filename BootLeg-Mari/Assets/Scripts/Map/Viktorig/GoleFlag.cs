using UnityEngine;
using TMPro;

public class GoleFlag : MonoBehaviour
{
    [SerializeField] GameObject _winUi;

    [Header("PlayerScore")]
    [SerializeField] protected TMP_Text _score, _jokeText;

    [Header("Win text 0 = S and you haev to Write 6 ind total")]
    [SerializeField] protected string[] WinTexts;

    private void OnTriggerEnter(Collider other)
    {
        _winUi.SetActive(true);
        MariValues.MariIsDead = true;
        FindObjectOfType<AudioMangerScript>().PlayAudio("WinFanfar", true);
        ScoreToPlayer();
    }

    protected virtual void ScoreToPlayer()
    {
        Debug.Log("the skore is " + WorldValues.ScoreSunCoinsColleted + " and the player died = " + WorldValues.ScoreHasPlayerDied);

        // shows the player skore
        if (WorldValues.ScoreSunCoinsColleted == 3 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "Axolotl";
            _score.fontSize = 65;
            _score.enableWordWrapping = false;
            _jokeText.text = WinTexts[0];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 3)
        {
            _score.text = "A";
            _jokeText.text = WinTexts[1];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 2)
        {
            _score.text = "B";
            _jokeText.text = WinTexts[2];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 1)
        {
            
            _score.text = "C";
            _jokeText.text = WinTexts[3];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 0 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "D";
            _jokeText.text = WinTexts[4];
        }
        else
        {
            _score.text = "F";
            _jokeText.text = WinTexts[5];
        }
    }
}
