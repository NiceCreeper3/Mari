using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoleFlag : MonoBehaviour
{
    [SerializeField] GameObject _winUi;

    [Header("PlayerScore")]
    [SerializeField] TMP_Text _score, _jukeText;

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
            _jukeText.text = "Congrats you wasted you life ind the beast way posebol. by not realising you did";
        }
        else if (WorldValues.ScoreSunCoinsColleted == 3)
        {
            _score.text = "A";
            _jukeText.text = "MY GOD. you arent complitlig inkompetent. NOW DO BEADER";
        }
        else if (WorldValues.ScoreSunCoinsColleted == 2)
        {
            _score.text = "B";
            _jukeText.text = "Do you like vanila... no? is your name joe.. no? THEN DO BETER NEXT TIME BOKO";
        }
        else if (WorldValues.ScoreSunCoinsColleted == 1)
        {
            
            _score.text = "C";
            _jukeText.text = "Don,t worring i will add a disbeld mode next time for you. but good try";
        }
        else if (WorldValues.ScoreSunCoinsColleted == 0 && WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "F";
            _jukeText.text = "did you know. according to all known laws of deviation. there is no way you can suck that bad";
        }
        else
        {
            _score.text = "D";
            _jukeText.text = "DO YOU NOT HAVE EYES!";

        }

    }
}
