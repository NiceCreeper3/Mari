using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    // Values
    #region
    // (getes the bosses states shothe as healt and AttackCoolDown)
    [SerializeField] private BossStatesSB bossStatesSB;

    // (deturmens if the boss is alive)
    private bool _bossIsAlive = true;

    // (boos stage)
    private ushort _bossStage;

    [Header("head")]
    [SerializeField] private Transform _creatureHead;

    private CreatureHeadSkript GetHitEvent;

    // (Attack events)
    [Header("Attack events")]
    [SerializeField] private GameEventScriptebolObjecks OnAttackLasherSend;
    [SerializeField] private GameEventScriptebolObjecks OnAttackMissails;
    [SerializeField] private GameEventScriptebolObjecks OnAttackDoomShere;
    [SerializeField] private GameEventScriptebolObjecks OnAttackHeadBash;

    [Header("Death Partitals")]
    [SerializeField] ParticleSystem[] _deathPartitals;
    [SerializeField] GameObject _vitureFlag, _viturePlatform;


    // indekaets how meny attackes the boss can do beafore he can be hit
    private ushort attacksTilWeak = 0;
    #endregion

    // Method Triggeres
    #region
    // Start is called before the first frame update
    void Start()
    {
        // sets the current healt of the boss and its setes its stage
        _bossStage = 1;

        // gets refrens to event
        GetHitEvent = _creatureHead.GetComponent<CreatureHeadSkript>();
        GetHitEvent.BossIsHit += GetHitEvent_BossIsHit;

        // Starts the bosses Attack 
        StartCoroutine(BossColddownAttack());
    }

    // boss takes damige
    private void GetHitEvent_BossIsHit()
    {
        // Swithes attacks and is alout to attack agien
        SwitcheStage();
        attacksTilWeak = 0;
    }

    #endregion

    // Methods
    #region

    // Boss Attack after som time
    private IEnumerator BossColddownAttack()
    {
        while (_bossIsAlive)
        {
            yield return new WaitForSecondsRealtime(bossStatesSB.BossAttackCoolDown);

            if (attacksTilWeak == 5)
            {
                // stopes the head from spining and then 
                OnAttackHeadBash.Raise(_bossStage);
            }
            else
            {
                Debug.Log("Rolles attack");
                Attack();

                
                //ads one to attacksTilWeak
                attacksTilWeak++;
            }
        }
    }


    void Attack()
    {
        // rooles what attack to do
        short attackRolle = (short)Random.Range(1, 4);
        Debug.Log("Attack is " + attackRolle + " is tire 1");

        switch (attackRolle)
        {
            // Makes missails fall from the sky
            case 1:
                OnAttackMissails.Raise(_bossStage);
                //RocketAttack?.Invoke(_bossStage);
                break;
            // Glides Lasheres akros
            case 2:
                OnAttackLasherSend.Raise(_bossStage);
                //LasherSendAttack?.Invoke(_bossStage);
                break;

            // Makes Sheres that chase the player
            case 3:
                OnAttackDoomShere.Raise(_bossStage);
                //DoomShereAttack?.Invoke(_bossStage);
                break;
        }
    }


    void SwitcheStage()
    {
        switch (_bossStage)
        {
            case 1:
                _bossStage = 2;
                break;

            case 2:
                _bossStage = 3;
                break;

            // Markes the boos as dead when he goves over 
            case 3:
                _bossIsAlive = false;
                CreatoureDeathParticals();
                break;
        }
    }

    void CreatoureDeathParticals() 
    {
        foreach (ParticleSystem effets in _deathPartitals)
        {
            effets.Play();

        }
        _vitureFlag.SetActive(true);
        _viturePlatform.SetActive(true);
    }
    #endregion
}