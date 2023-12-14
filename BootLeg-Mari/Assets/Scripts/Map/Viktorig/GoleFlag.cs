using UnityEngine;
using TMPro;

public class GoleFlag : MonoBehaviour
{
    [Header("PlayerScore")]
    [SerializeField] private ushort _mapProges;

    [Header("Win text 0 = S and you haev to Write 6 ind total")]
    [SerializeField] protected string[] WinTexts;


    [SerializeField] GameObject _winUi;

    [Header("PlayerScore")]
    [SerializeField] protected TMP_Text _score, _jokeText;

    private void Awake()
    {
        SaveSystem.CheackIfFolderAndFille();
    }

    private void OnTriggerEnter(Collider other)
    {   
        /// (Warning) needs to be change as it does not work
        /// is supposed to make so the player does not move when to UI is up
        /// But this is not intuvetive to look at ind code and does not prevent movement
        MariValues.MariIsDead = true;

        _winUi.SetActive(true);
        FindObjectOfType<AudioMangerScript>().PlayAudio("WinFanfar", true);
        ScoreToPlayer();
    }

    protected virtual void ScoreToPlayer()
    {
        Debug.Log("the skore is " + WorldValues.CurrentSunCoins + " and the player died = " + WorldValues.ScoreHasPlayerDied);

        // shows the player skore
        if (WorldValues.CurrentSunCoins == 3 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "Axolotl";
            _score.fontSize = 65;
            _score.enableWordWrapping = false;
            _jokeText.text = WinTexts[0];
        }
        else if (WorldValues.CurrentSunCoins == 3)
        {
            _score.text = "A";
            _jokeText.text = WinTexts[1];
        }
        else if (WorldValues.CurrentSunCoins == 2)
        {
            _score.text = "B";
            _jokeText.text = WinTexts[2];
        }
        else if (WorldValues.CurrentSunCoins == 1)
        {
            
            _score.text = "C";
            _jokeText.text = WinTexts[3];
        }
        else if (WorldValues.CurrentSunCoins == 0 && !WorldValues.ScoreHasPlayerDied)
        {
            _score.text = "D";
            _jokeText.text = WinTexts[4];
        }
        else
        {
            _score.text = "F";
            _jokeText.text = WinTexts[5];
        }
/*
        // reaplases the joke text so i can see what is goving on
        string teast = 
            $"the skore is {WorldValues.CurrentSunCoins} " +
            $"and the player died = {WorldValues.ScoreHasPlayerDied}. " +
            $"and player spawn is {WorldValues.HasGotCheckPoint}" +
            $"and saved suncoin is {WorldValues.SavedSunCoins}";
        _jokeText.text = teast;*/

        SaveProgres();
    }

      
    // Start is called before the first frame update
    private void SaveProgres()
    {
        // gets what to save
        #region
        // filles the SaveObject withe data 
        SaveSystem.SaveObject saveObject = new SaveSystem.SaveObject
        {
            GameLvlProgres = _mapProges
        };
        // converts the saveObject to jsons. we then save it ind a string as json is string based
        string convertedJson = JsonUtility.ToJson(saveObject);
        #endregion

        // saves the data if the player is not olredeig further
        #region
        string SaveString = SaveSystem.Load();

        // Gets loads the saved json data from the fille
        if (SaveString != null)
        {
            SaveSystem.SaveObject loadedSaveObject = JsonUtility.FromJson<SaveSystem.SaveObject>(SaveString);

            if (_mapProges > loadedSaveObject.GameLvlProgres || loadedSaveObject == null)
            {
                SaveSystem.Save(convertedJson);
            }
        }
        #endregion
    }
}
