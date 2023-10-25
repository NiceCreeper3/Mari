using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVictorig : GoleFlag
{

    protected override void ScoreToPlayer()
    {
        Debug.Log("the skore is " + WorldValues.ScoreSunCoinsColleted + " and the player died = " + WorldValues.ScoreHasPlayerDied);

        if (!WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "Axolotl";
            _score.fontSize = 65;
            _score.enableWordWrapping = false;
            _jokeText.text = WinTexts[0];
        }
        else
        {
            _score.text = "F";
            _jokeText.text = WinTexts[1];
        }
    }
}
