using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol
{
    /// <summary>
    /// To fix / thange
    /// the player can et inves frame by taking damige and avoit kille zone
    /// Interface Vs Event implemetason
    /// </summary>

    [SerializeField] float _inviseFamesTime;

    [Header("stuff ind inspeckter")]
    [SerializeField] GameObject _deaidTextUis;
    [SerializeField] Material _hitColor, _normalcolor;

    // Deturmes if mari can be hit agien
    private bool MariInviseFrame = false;

    /// shows how mane times the player kan be hit before die ing
    /// Origen: MariDead
    ///Is linked: MariDead, KillFloor, MariMove2
    private short _health;

    private void Start()
    {
        // Reasets the Playeres HP
        _health = 3;
    }

    public void ObjegtHasBenHit(short HitDamige)
    {
        ThePlayerIsHit(HitDamige);
    }

    //is interface method
    private void ThePlayerIsHit(short HitDamige)
    {
        if (!MariInviseFrame)
        {
            _health -= HitDamige;

            Debug.Log($"HP is Right now {_health} and the player has takken {HitDamige}");

            FindObjectOfType<AudioMangerScript>().PlayAudio("HitSound", true);

            // makes it so enemyes kant          
            StartCoroutine(StartMariHitCooldown());
        }

        /// Checks if the player has reathed 0 HP
        /// if then the player dies and the scene is reaset
        if (_health <= 0 && MariValues.MariIsDead == false)
        {
            Debug.Log("Player has died");
            StartCoroutine(PalyerReaspawn());
        }

    }

    // gives the player som invincebiletig time after there have ben hit
    IEnumerator StartMariHitCooldown()
    {
        // makes it so player can.t be hit
        MariInviseFrame = true;

        // Colores the player Whit to dendikat that the player has ben hit and has invis frames
        for(int i = 1; i <= 3; i+= 1)
            gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = _hitColor.color;

        yield return new WaitForSecondsRealtime(_inviseFamesTime);

        // turens the player back to normal color to dendikat that the player no longer has invis frames
        for (int i = 1; i <= 3; i += 1)
            gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = _normalcolor.color;

        // ends invis frames
        MariInviseFrame = false;
    }

    private IEnumerator PalyerReaspawn()
    {
        // Shows the player det Ui that sease that there are dead
        _deaidTextUis.SetActive(true);

        // sets so the player cant move wille ded
        MariValues.MariIsDead = true;

        // playes a audio wen player dies
        FindObjectOfType<AudioMangerScript>().PlayAudio("DeadAudio", true);
       
        //  Telles Mari has died atleast ones. wiht reflekts on score
        WorldValues.ScoreHasPlayerDied = true;

        // waits so player can read messige and then realoads the scene loads 
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _deaidTextUis.SetActive(false);
    }

}

