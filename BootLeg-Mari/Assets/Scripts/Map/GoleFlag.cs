using UnityEngine;
using TMPro;

public class GoleFlag : MonoBehaviour
{
    [SerializeField] GameObject _winUi;

    [Header("PlayerScore")]
    [SerializeField] TMP_Text _score, _jukeText;

    [Header("Win text 0 = S and you haev to Write 6 ind total")]
    [SerializeField] string[] WinTexts;

    private void OnTriggerEnter(Collider other)
    {
        _winUi.SetActive(true);
        MariValues.MariIsDead = true;
        FindObjectOfType<AudioMangerScript>().PlayAudio("WinFanfar", true);
        ScoreToPlayer();
    }

    void ScoreToPlayer()
    {
        Debug.Log("the skore is " + WorldValues.ScoreSunCoinsColleted + " and the player died = " + WorldValues.ScoreHasPlayerDied);

        // shows the player skore
        if (WorldValues.ScoreSunCoinsColleted == 3 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "S";
            _jukeText.text = WinTexts[0];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 3)
        {
            _score.text = "A";
            _jukeText.text = WinTexts[1];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 2)
        {
            _score.text = "B";
            _jukeText.text = WinTexts[2];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 1)
        {
            
            _score.text = "C";
            _jukeText.text = WinTexts[3];
        }
        else if (WorldValues.ScoreSunCoinsColleted == 0 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "D";
            _jukeText.text = WinTexts[4];
        }
        else
        {
            _score.text = "F";
            _jukeText.text = WinTexts[5];
        }

    }
}
