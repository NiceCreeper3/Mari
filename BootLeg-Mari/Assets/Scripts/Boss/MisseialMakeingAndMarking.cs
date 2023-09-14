using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisseialMakeingAndMarking : MonoBehaviour
{
    ushort _howHighToSetRocket;

    Transform _spot;


    Transform _rocket;

    // Start is called before the first frame update
    void Start()
    {
        _spot = transform.GetChild(0);
        _rocket = transform.GetChild(1);

        //Boss boss = GetComponent<Boss>();
        //boss.RocketAttack += Boss_RocketAttack;
    }

    private void Boss_RocketAttack()
    {
        // 
        _spot.gameObject.SetActive( true);

        SentRocket();
    }

    void SentRocket()
    {
        //Sents the Rocket

        _rocket.position = new Vector3(_spot.position.x, _howHighToSetRocket, _spot.position.z);
        _rocket.gameObject.SetActive(true);
    }

}
