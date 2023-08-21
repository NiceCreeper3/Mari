using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomba : Monster, IJumpable, IShootebol
{

    private void OnTriggerStay(Collider other)
    {
        AttackPlayer(other);
    }

    void IJumpable.JumpetOn(int hit)
    {
        FindObjectOfType<AudioMangerScript>().PlayAudio("GombaStomp", true);
        EnemyHit();

        MariValues.Velocity.y = Mathf.Sqrt((MariValues.JumpHight * -2f * MariValues.Gravity) / 2);
    }


    //Methodes
    #region
    void IShootebol.Shoot()
    {
        FindObjectOfType<AudioMangerScript>().PlayAudio("GombaStomp", true);
        EnemyHit();
    }

    #endregion
}
