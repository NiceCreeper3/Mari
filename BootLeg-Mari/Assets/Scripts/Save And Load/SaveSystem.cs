using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static readonly string Save_Folder = Application.dataPath + "/PlayerProgres/";

    public static void Init()
    {
        //test if save Folder exists. if not then it creats one
        if (!Directory.Exists(Save_Folder))
        {
            // creats a save follder
            Directory.CreateDirectory(Save_Folder);
        }
    }

    // saves the given String Data
    public static void Save(string saveInfo)
    {
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
}
