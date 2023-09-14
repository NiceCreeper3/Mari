using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MariDead : MonoBehaviour, IIsHitebol
{
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
        DamigePlayer damigePlayer = GetComponent<DamigePlayer>();
        damigePlayer.PlayerIsHit += DamigePlayer_PlayerIsHit; 
        _health = 3;
    }

    private void DamigePlayer_PlayerIsHit(int obj)
    {
        throw new NotImplementedException();
    }

    //is interface method
    public void ObjegtHasBenHit(short HitDamige)
    {
        if (!MariInviseFrame)
        {
            _health -= HitDamige;
            FindObjectOfType<AudioMangerScript>().PlayAudio("HitSound", true);

            // makes it so enemyes kant          
            StartCoroutine(StartMariHitCooldown());
        }

        if (_health <= 0)
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
        for(int i = 1; i <= 3; i+= 1)
            gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = _hitColor.color;

        yield return new WaitForSecondsRealtime(_inviseFamesTime);

        for (int i = 1; i <= 3; i += 1)
            gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = _normalcolor.color;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _deaidTextUis.SetActive(false);
    }
}

