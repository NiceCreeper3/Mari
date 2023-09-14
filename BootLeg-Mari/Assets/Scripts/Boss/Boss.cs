using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour, IJumpable
{
    // Values
    #region
    // getes the bosses states shothe as healt and AttackCoolDown
    [SerializeField] private BossStatesSB bossStatesSB;
    private short _bossHealt;

    // deturmens if the boss is alive
    private bool _bossIsAlive = true;

    // is the calles the difrent attackes the boos can do
    private Action BossAtack;

    public event Action RocketAttack;

    private enum bossStages
    {
        Stage_1,
        Stage_2,
        Stage_3
    }
    private bossStages _currentStage;
    #endregion

    // Method Triggeres
    #region
    // Start is called before the first frame update
    void Start()
    {
        _bossHealt = bossStatesSB.BossMaxHealt;
        _currentStage = bossStages.Stage_1;
        BossAtack = Stage1Attack;

        // Starts the bosses Attack 
        StartCoroutine(BossColddownAttack());
    }

    public void JumpetOn(int hit)
    {
        BossHealtMangement();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 0, 1, Space.Self);

    }
    #endregion

    // Methods
    #region
    void SwitcheStage()
    {
        switch (_currentStage)
        {
            case bossStages.Stage_1:
                _currentStage = bossStages.Stage_2;
                BossAtack = Stage2Attack;
                break;

            case bossStages.Stage_2:
                BossAtack = Stage3Attack;
                _currentStage = bossStages.Stage_3;
                break;
        }
    }

    void BossHealtMangement() 
    {
        _bossHealt -= 1;
        if(_bossHealt <= 0)
            _bossIsAlive = false;

        SwitcheStage();
    }


    private IEnumerator BossColddownAttack()
    {
        while (_bossIsAlive)
        {
            yield return new WaitForSecondsRealtime(bossStatesSB.BossAttackCoolDown);
            BossAtack?.Invoke();
        }
    }

    void Stage1Attack()
    {
        short AttackToDo = (short)Random.Range(1, 6);

        switch (AttackToDo)
        {
            case 1:
                RocketAttack?.Invoke();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }
    void Stage2Attack()
    {

    }

    void Stage3Attack()
    {

    }

    #endregion

}
