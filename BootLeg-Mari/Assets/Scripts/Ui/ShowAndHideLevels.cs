using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideLevels : MonoBehaviour
{
    [SerializeField] private ushort _showOnLvlProgres;

    private void Awake()
    {
        SaveSystem.CheackIfFolderAndFille();

        string loadString = SaveSystem.Load();
        SaveSystem.SaveObject convertedLoad = JsonUtility.FromJson<SaveSystem.SaveObject>(loadString);

        Debug.Log(convertedLoad);

        if (_showOnLvlProgres <= convertedLoad.GameLvlProgres)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

}
