using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossStates", menuName = "Boss/BossesStats")]
public class BossStatesSB : ScriptableObject
{
    [Header("The bosses starting healt")]
    public short BossMaxHealt;

    [Header("how long the boss have to wait before it can attack agien")]
    public short BossAttackCoolDown;
}
