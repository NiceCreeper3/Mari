using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol
{
    [SerializeField] GameObject _deaidTextUis;
    [SerializeField] float _inviseFamesTime;

    // Deturmes if mari can be hit agien
    private bool MariInviseFrame = false;

    //is interface method
    public void ObjegtHasBenHit(short HitDamige)
    {
        if (!MariInviseFrame)
        {
            MariValues.Health -= HitDamige;
            // makes it so enemyes kant 
            StartCoroutine(StartMariHitCooldown());
        }


        if (MariValues.Health <= 0)
        {
            Debug.Log("Player has died");
            StartCoroutine(PalyerReaspawn());
        }
    }

    // gives the player som invincebiletig time after there have ben hit
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

        // playes a audio wen player dies
        FindObjectOfType<AudioMangerScript>().PlayAudio("DeadAudio", true);
       
        //  Telles Mari has died atleast ones. wiht reflekts on score
        WorldValues.ScoreHasPlayerDied = true;

        // sets so the player cant move wille ded
        MariValues.MariIsDead = true;

        // waits so player can read messige and then realoads the scene loads 
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MariMap");
        _deaidTextUis.SetActive(false);
    }
}

