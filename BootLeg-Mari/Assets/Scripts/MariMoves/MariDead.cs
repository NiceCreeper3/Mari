using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol
{
    [SerializeField] GameObject _deaidTextUis;
    [SerializeField] float _inviseFamesTime;

    // Deturmes if mari can be hit agien
    private bool MariInviseFrame = false;

    public void ObjegtHasBenHit(short HitDamige)
    {
        if (!MariInviseFrame)
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
        MariInviseFrame = true;
        yield return new WaitForSecondsRealtime(_inviseFamesTime);
        MariInviseFrame = false;
    }

    public IEnumerator PalyerReaspawn()
    {
        // Makes it Mari doeset do enithing for a wille
        _deaidTextUis.SetActive(true);


        // reasets the 
        MariValues.MariIsDead = true;
        yield return new WaitForSecondsRealtime(2f);

        //
        SceneManager.LoadScene("MariMap");
        _deaidTextUis.SetActive(false);
    }
}

