using UnityEngine;

public class Gomba : Monster, IJumpable, IShootebol
{
    private void OnTriggerStay(Collider other)
    {
        AttackPlayer(other);
    }

    void IJumpable.JumpetOn(int hit)
    {
        StartCoroutine(EnemyHit("GombaStomp"));
    }

    //Methodes
    #region
    void IShootebol.Shoot()
    {
        //FindObjectOfType<AudioMangerScript>().PlayAudio("GombaStomp", true);
        StartCoroutine(EnemyHit("GombaStomp"));
    }

    #endregion
}
