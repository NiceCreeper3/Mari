using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol, IIsOneshottebol
{
    [Header("stuff ind inspeckter")]
    [SerializeField] private GameObject _deaidTextUis;
    [SerializeField] private Material _hitColor, _normalcolor;
    [SerializeField] private GameEventScriptebolObjecks _onHitOpdateUI;

    // Deturmes if mari can be hit agien
    private bool MariInviseFrame = false;

    /// holds the Playeres Healt and start healt
    /// and four how long the player can be invinsebol
    [SerializeField] private MariHealtScriptebolObjeckt mariHealtStats;

    private void Start()
    {
        // Reasets the Playeres HP
        mariHealtStats.PlayerCurrentHealt = mariHealtStats.PlayerStartHealt;
        //_health = 3;
    }

    // is called when the player is hit by somthing
    public void ObjegtHasBenHit(short HitDamige)
    {
        ThePlayerIsHit(HitDamige);
    }

    // is called by things that one shoot the player
    public void IsOneshoot()
    {
        if(!MariValues.MariIsDead)
            StartCoroutine(PalyerReaspawn());
    }

    //is interface method
    private void ThePlayerIsHit(short HitDamige)
    {
        if (!MariInviseFrame)
        {
            // removes the given HP from player, and playes a hit nouse to indkate the player got gik
            mariHealtStats.PlayerCurrentHealt -= HitDamige;
            FindObjectOfType<AudioMangerScript>().PlayAudio("HitSound", true);

            //Opdates the UI to Show the playeres current hp
            _onHitOpdateUI.Raise(mariHealtStats.PlayerCurrentHealt);

            Debug.Log($"HP is Right now {mariHealtStats.PlayerCurrentHealt} and the player has takken {HitDamige}");

            // makes it so enemyes kant          
            StartCoroutine(StartMariHitCooldown());
        }

        /// Checks if the player has reathed 0 HP
        /// if then the player dies and the scene is reaset
        if (mariHealtStats.PlayerCurrentHealt <= 0 && !MariValues.MariIsDead)
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

        yield return new WaitForSecondsRealtime(mariHealtStats.InviseFamesTime);

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

