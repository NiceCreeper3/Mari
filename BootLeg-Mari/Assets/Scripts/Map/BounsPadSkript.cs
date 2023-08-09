using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsPadSkript : MonoBehaviour, IJumpable
{
    [Header("How highe the player wil bouns")]
    [SerializeField] float _maxBounse;
    [SerializeField] float _normalBounse;

    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("Platform hit");
        BoundsPlayer();
    }

    void BoundsPlayer()
    {
        // will make the player bouns estrer high if there press jump 
        if (Input.GetButton("Jump"))
        {
            MariValues.Velocity.y = _maxBounse;
        }
        else
        {
            MariValues.Velocity.y = _normalBounse;
        }
    }

}
