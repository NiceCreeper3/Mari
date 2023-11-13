using UnityEngine;

[CreateAssetMenu(fileName = "BossStates", menuName = "Boss/BossesStats")]
public class BossStatesSB : ScriptableObject
{
    [Header("The bosses starting healt")]
    public short BossMaxHealt;

    [Header("the time ontel the boss does its first attack")]
    public short TimeOnTilFirstAttack;

    [Header("how long the boss have to wait before it can attack ")]
    // is the time indbetvine attacks ind the first stage
    public short StageOneAttackCoolDown;
    // is the time indbetvine attacks ind the all other statges
    public short NormalAttackCoolDown;
    
}
