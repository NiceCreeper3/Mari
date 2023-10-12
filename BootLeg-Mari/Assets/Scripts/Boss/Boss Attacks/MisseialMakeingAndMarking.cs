using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisseialMakeingAndMarking : MonoBehaviour
{
    // values
    #region
    [Header("Times inbetvine Missials")]
    [SerializeField] float _firstStageMissailsTime;
    [SerializeField] float _timeIndBetvinVolligs;
    [SerializeField] float _stage3IndBeatvineTime;

    [Header("How many missails to sendt")]
    [SerializeField] ushort _SendtOnStageOne;
    [SerializeField] ushort _SendtOnStageTre;

    // list of all the rockets
    private List<Transform> _rocketSpotes = new List<Transform>();
    private List<int> _olredeRolled;

    #endregion

    // triggeres
    #region
    // Start is called before the first frame update
    void Awake()
    {
        _olredeRolled = new List<int>();

        // gets all posbol Rockets and adds them to a lsit
        foreach (Transform rocket in transform)
            _rocketSpotes.Add(rocket.GetChild(0));          
    }

    public void SendtMissials(object data )
    {
        ushort attackStage = (ushort)data;

        // does a diffrent attack depending on the stage
        switch (attackStage)
        {
            case 1:
                StartCoroutine(RocketsSent(_SendtOnStageOne, _firstStageMissailsTime));
                break;
            case 2:
                StartCoroutine(LinepatternOfRockets());
                break;
            case 3:
                StartCoroutine(CompoAttack());
                break;
        }
    }
    #endregion

    // methodes??? IEnumratures
    #region
    private IEnumerator RocketsSent(ushort howMenyRocketsToSent, float timeIndBetvinMissal)
    {
        for (int i = 0; i < howMenyRocketsToSent; i++)
        {
            //get a random nummber. and that random nummber is the Rocekt to send
            int rocketToSent = RollNoReaoite();

           // Spawns a endekator and missaial
           _rocketSpotes[rocketToSent].gameObject.SetActive(true);

            yield return new WaitForSecondsRealtime(timeIndBetvinMissal);
        }

        _olredeRolled.Clear();
    }

    private IEnumerator LinepatternOfRockets()
    {
        // is how many rockets have ben sent
        ushort volligCount = 0;

        foreach(Transform transform in _rocketSpotes)
        {
            // Makes et so it pauses after fireing 3 Missails
            if (volligCount >= 3)
            {
                volligCount = 0;
                yield return new WaitForSecondsRealtime(_timeIndBetvinVolligs);
            }
            
            // Spawns a missial
            transform.gameObject.SetActive(true);
            volligCount++;
        }
    }

    private IEnumerator CompoAttack()
    {

        StartCoroutine(LinepatternOfRockets());


        yield return new WaitForSecondsRealtime(_stage3IndBeatvineTime);

        // No work
        int missingMissails = 0;
        while (missingMissails == _SendtOnStageTre)
        {

            StartCoroutine(RocketsSent(_SendtOnStageTre, 0));
            missingMissails++;
            yield return new WaitForSecondsRealtime(3);
        } 

    }

    private int RollNoReaoite()
    {
        bool hasNotFoundUnikeNummber = true;
        int missailToSent = 0;

        while (hasNotFoundUnikeNummber)
        {
            //get a random nummber. and that random nummber is the missail to send
            missailToSent = Random.Range(0, _rocketSpotes.Count);

            // starts by making it end the shikel
            hasNotFoundUnikeNummber = false;

            // it then checks all the nummberes ind the List. if enig are the same as the random nummber
            // then it makes it so it continuse the shicel
            foreach (int isNotDubleket in _olredeRolled)
            {
                if (missailToSent == isNotDubleket)
                    hasNotFoundUnikeNummber = true;               
            }
        }

        _olredeRolled.Add(missailToSent);
        return missailToSent;

/*
        foreach (int eamtigRoll in _olredeRolled)
            _olredeRolled.Remove(eamtigRoll);*/
    }

    #endregion
}
