using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.EditorCoroutines.Editor;

//[CustomEditor(typeof(Teleport))]
public class Teleport : EditorWindow
{
    private GameObject _teleport1, _teleport2, _teleport3, _teleport4, _teleport5, _mariTeleport;
    [SerializeField] short _toTeleport;

    private void OnEnable()
    {
        _teleport1 = GameObject.Find("Tel1");
        _teleport2 = GameObject.Find("Tel2");
        _teleport3 = GameObject.Find("Tel3");
        _teleport4 = GameObject.Find("Tel4");
        _teleport5 = GameObject.Find("Tel5");

        // gets mari so he can teleport
        _mariTeleport = GameObject.Find("Mari");

        Debug.Log("Editor is enable");
    }

    [MenuItem("Window/TeleportWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Teleport>("Tel");
    }

    private void OnGUI()
    {
        //Teleport (Does not work)
        #region
        GUILayout.Label("Teleport to lokason");
        _toTeleport = (short)EditorGUILayout.Slider(_toTeleport, 1, 5);

        if (GUILayout.Button("Teleport"))
        {

            // desides where to teleport
            if (Input.GetKeyDown("1"))
            {
                //EditorCoroutineUtility.StartCoroutineOwnerless(TeleportDev(_teleport1));
            }
            if (Input.GetKeyDown("2"))
            {             
                EditorCoroutineUtility.StartCoroutineOwnerless(TeleportDev(_teleport2));
            }
            if (Input.GetKeyDown("3"))
            {                
                EditorCoroutineUtility.StartCoroutineOwnerless(TeleportDev(_teleport3));
            }
            if (Input.GetKeyDown("4"))
            {               
                EditorCoroutineUtility.StartCoroutineOwnerless(TeleportDev(_teleport4));
            }
            if (Input.GetKeyDown("5"))
            {               
                EditorCoroutineUtility.StartCoroutineOwnerless(TeleportDev(_teleport5));
            }
        }
        #endregion

        GUILayout.Space(10);

        //reaset Sce
        #region
        // Reasets the scene
        GUILayout.Label("Reaset the kurrent scene");
        if (GUILayout.Button("Reaset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion

        GUILayout.Space(10);

        // score reshet
        #region
        // Reasets the scene
        GUILayout.Label("Reasets the Score Rekriverments");
        if (GUILayout.Button("Reaset Score"))
        {
            //Reasets score rikvaerments
            WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;
        }
        #endregion
    }

    // teleportes me to desired lokason
    public IEnumerator TeleportDev(GameObject PlayesToTeleport )
    {      
        MariValues.PlayerIsTeleporting = true;
        yield return new WaitForSecondsRealtime(0.5f);
        _mariTeleport.transform.position = PlayesToTeleport.transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        MariValues.PlayerIsTeleporting = false;
        Debug.Log("you have teleported to " + PlayesToTeleport.name);
    }
}
