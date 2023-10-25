using UnityEngine;
using System.IO;

public static class SaveSystem
{
    //gets a refens to the save folder
    public static readonly string Save_Folder = Application.dataPath + "/PlayerProgres/";

    public static void CheackIfFolderAndFille()
    {
        Debug.Log("cheking if there is a SaveFollder");

        //test if save Folder exists. if not then it creats one
        if (!Directory.Exists(Save_Folder))
        {
            // creats a save follder
            Directory.CreateDirectory(Save_Folder);

            Debug.Log("Savefolder has bean created");
        }

        // checkes if save exists if not then it makes a 
        if (!File.Exists(Save_Folder + "/save.txt"))
        {
            SaveObject saveObject = new SaveObject
            {
                GameLvlProgres = 0
            };
            string saveConvertedToJson = JsonUtility.ToJson(saveObject);

            Save(saveConvertedToJson);
            Debug.Log("Save fille has bean created");
        }
    }




    // saves the given String Data
    public static void Save(string saveInfo)
    {
        Debug.Log("Game has saved");
        File.WriteAllText(Save_Folder + "save.txt", saveInfo);
    }

    /// first checkes if we have a save fille
    /// and then reads all content ind if we do.
    /// and if we don,t then it returns null
    public static string Load()
    {
        // checkes if save exists
        if (File.Exists(Save_Folder + "/save.txt"))
        {
            // reads all the data ind fille and then reaturns it
            string saveString = File.ReadAllText(Save_Folder + "/save.txt");
            return saveString;
        }
        else // gives null if there is no save fille
            return null;
    }

    // all the save types
    #region
    //Contanes data we want to save
    public class SaveObject
    {
        public ushort GameLvlProgres;
    }
    #endregion
}
