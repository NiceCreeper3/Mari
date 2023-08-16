using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private GameObject _teleport1, _teleport2, _teleport3, _teleport4, _teleport5, _mariTeleport;

    private void Start()
    {
        try
        {
            _teleport1 = GameObject.Find("Tel1");
            _teleport2 = GameObject.Find("Tel2");
            _teleport3 = GameObject.Find("Tel3");
            _teleport4 = GameObject.Find("Tel4");
            _teleport5 = GameObject.Find("Tel5");
        }
        catch
        {
            Debug.LogError("You dident name a teleport correktlig");
        }

        try
        {
            _mariTeleport = GameObject.Find("Mari");
        }
        catch
        {
            Debug.LogError("You can,t rithe mari");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            StartCoroutine(TeleportDev(_teleport1));
        }
        if (Input.GetKeyDown("2"))
        {
            StartCoroutine(TeleportDev(_teleport2));
        }
        if (Input.GetKeyDown("3"))
        {
            StartCoroutine(TeleportDev(_teleport3));
        }
        if (Input.GetKeyDown("4"))
        {
            StartCoroutine(TeleportDev(_teleport4));
        }
        if (Input.GetKeyDown("5"))
        {
            StartCoroutine(TeleportDev(_teleport5));
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // teleportes me to desired lokason
    private IEnumerator TeleportDev(GameObject PlayesToTeleport )
    {      
        MariValues.PlayerIsTeleporting = true;
        yield return new WaitForSecondsRealtime(0.5f);
        _mariTeleport.transform.position = PlayesToTeleport.transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        MariValues.PlayerIsTeleporting = false;
        Debug.Log("you have teleported to " + PlayesToTeleport.name);
    }
}
