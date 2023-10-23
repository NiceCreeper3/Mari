using UnityEngine;

[CreateAssetMenu(fileName = "MariScriptableObjects", menuName = "MariScriptableObjects/MovmentStates")]
public class MariMovmentStatesSB : ScriptableObject
{
    // <movment>
    [Header("Movment")]
    public float Speed;

    // <turning>
    [Header("Turning the Player")]
    public float TurnSmoothTime = 0.1f;
    
    [Header("how fast the plater is on ice")]
    public float SlideSpeed;
}
