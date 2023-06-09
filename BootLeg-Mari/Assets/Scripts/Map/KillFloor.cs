using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillFloor : MonoBehaviour
{
    public GameObject DeaidTextUi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit KilleZone");
            StartCoroutine(PalyerReaspawn());           
        }
        else if (!other.CompareTag("PlatForm"))
        {
            Destroy(other.gameObject);
            Debug.Log(other.gameObject);
        }
    }

    IEnumerator PalyerReaspawn()
    {
        // Makes it Mari doeset do enithing for a wille
        DeaidTextUi.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene("MariMap");
        DeaidTextUi.SetActive(false);
    }
}
