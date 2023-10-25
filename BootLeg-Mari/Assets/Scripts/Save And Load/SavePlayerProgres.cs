using UnityEngine;

public class SavePlayerProgres : MonoBehaviour
{
    [SerializeField] private ushort _mapProges;

    private void Awake()
    {
        SaveSystem.CheackIfFolderAndFille();
    }

    // Start is called before the first frame update
    public void SaveProgres()
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
