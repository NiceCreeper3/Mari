using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerProgres : MonoBehaviour
{

    [SerializeField] private ushort _whatStageThePlayerIsAt; 

    // Start is called before the first frame update
    void Start()
    {
        // filles the SaveObject withe data 
        SaveObject saveObject = new SaveObject
        {
            GameProgres = _whatStageThePlayerIsAt
        };

        // converts the info ind saveObject to jsons. we then save it ind a string as json is string based
        string convertedJson = JsonUtility.ToJson(saveObject);

        // Gets loads the saved json data from the fille
        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(convertedJson);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Contanes data we want to save
    private class SaveObject
    {
        public ushort GameProgres;
    }
}
