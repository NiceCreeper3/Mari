using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol
{
    public GameObject DeaidTextUi;
    [SerializeField] float InviseFamesTime;

    public void ObjegtHasBenHit(short HitDamige)
    {
        if (!MariValues.MariInviseFrame)
        {
            MariValues.Healf -= HitDamige;
            // makes it so enemyes kant 
            StartCoroutine(StartMariHitCooldown());
        }


        if (MariValues.Healf <= 0)
        {
            Debug.Log("Player has died");
            StartCoroutine(PalyerReaspawn());
        }
    }

    // gives the player som invincebiletig time
    IEnumerator StartMariHitCooldown()
    {
        MariValues.MariInviseFrame = true;
        yield return new WaitForSecondsRealtime(InviseFamesTime);
        MariValues.MariInviseFrame = false;
    }

    public IEnumerator PalyerReaspawn()
    {
        // Makes it Mari doeset do enithing for a wille
        DeaidTextUi.SetActive(true);


        // reasets the 
        MariValues.MariIsDead = true;
        yield return new WaitForSecondsRealtime(2f);

        //
        SceneManager.LoadScene("MariMap");
        DeaidTextUi.SetActive(false);
    }
}

