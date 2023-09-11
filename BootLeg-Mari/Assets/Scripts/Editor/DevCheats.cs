using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class DevCheats : EditorWindow
{
    private GameObject _teleport0, _teleport1, _teleport2, _teleport3, _teleport4, _teleport5, _mariTeleport;
    [SerializeField] short _toTeleport;

    bool reasetOrMax = false;

    [MenuItem("Window/DevCheats")]
    public static void ShowWindow()
    {
        GetWindow<DevCheats>("DevCheats");
    }

    //
    private void OnEnable()
    {
        GetStuff();

        Debug.Log("Editor is enable");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        //Teleport
        TeleportDev();

        GUILayout.Space(10);

        ReasetScene();

        GUILayout.Space(10);

        ReasetScore();

        GUILayout.Space(5);

        SetHealth();
    }



    //Methodes
    #region
    // gets the teleport plases
    void GetStuff()
    {
        _teleport0 = GameObject.Find("Tel0");
        _teleport1 = GameObject.Find("Tel1");
        _teleport2 = GameObject.Find("Tel2");
        _teleport3 = GameObject.Find("Tel3");
        _teleport4 = GameObject.Find("Tel4");
        _teleport5 = GameObject.Find("Tel5");

        // gets mari so he can teleport
        _mariTeleport = GameObject.Find("Mari");
    }

    void TeleportDev()
    {
        GUILayout.Label("reafeges the teleport spots");
        if (GUILayout.Button("Reaset Telport"))
            GetStuff();

        // gives the lokason you want to teleport to
        GUILayout.Label("Teleport to lokason");
        _toTeleport = (short)EditorGUILayout.Slider(_toTeleport, 0, 5);



        if (GUILayout.Button("Teleport"))
        {
            try
            {
                // desides where to teleport
                if (_toTeleport == 0)
                {
                    _mariTeleport.transform.position = _teleport0.transform.position;
                }
                if (_toTeleport == 1)
                {
                    // teleports the player to the lokason of Tel1
                    _mariTeleport.transform.position = _teleport1.transform.position;
                }
                if (_toTeleport == 2)
                {
                    _mariTeleport.transform.position = _teleport2.transform.position;
                }
                if (_toTeleport == 3)
                {
                    _mariTeleport.transform.position = _teleport3.transform.position;
                }
                if (_toTeleport == 4)
                {
                    _mariTeleport.transform.position = _teleport4.transform.position;
                }
                if (_toTeleport == 5)
                {
                    _mariTeleport.transform.position = _teleport5.transform.position;
                }
            }
            catch
            {
                Debug.LogError("you need to reafreas the teleports");
            }
        }
    }

    void ReasetScene()
    {
        // Reasets the scene
        GUILayout.Label("Reaset the kurrent scene");
        if (GUILayout.Button("Reaset"))
        {         
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GetStuff();
        }
    }

    void ReasetScore()
    {
        // Reasets the scene
        reasetOrMax = GUILayout.Toggle(reasetOrMax, "MaxScore = true, reaset = false");

        GUILayout.Space(5);

        GUILayout.Label("Reasets/Max the Score Rekriverments");
        if (GUILayout.Button("set Score"))
        {
            if (reasetOrMax)
            {
                Debug.Log("Full points");
                WorldValues.ScoreSunCoinsColleted = 3;
            }
            else
            {
                Debug.Log("Points reset");
                WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;
                WorldValues.ScoreSunCoinsColleted = 0;
            }

            //Reasets score rikvaerments

        }
    }

    void SetHealth()
    {
        GUILayout.Label("sets the playeres Health to what you want");
        short setHealth = (short)EditorGUILayout.Slider(_toTeleport, 0, 10);

        if (GUILayout.Button("set Health"))
        {
            MariValues.Health = setHealth;
            WorldValues.ScoreHasPlayerDied = false;
        }
    }
    #endregion
}
