using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform _teleport1, _teleport2, _teleport3, _teleport4, _teleport5;

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

    private IEnumerator TeleportDev(Transform PlayesToTeleport )
    {      
        MariValues.PlayerIsTeleporting = true;
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = PlayesToTeleport.transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        MariValues.PlayerIsTeleporting = false;
        Debug.Log("you have teleported to " + PlayesToTeleport.name);
    }
}
