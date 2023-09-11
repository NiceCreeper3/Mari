using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    //Values
    #region
    // Gravity stats
    [SerializeField] MariGravityScriptabolObject _mariGravity;

    // is the box that checkes if it thothes the ground
    [SerializeField] Transform _mariLegs;

    // can maby remove
    [SerializeField] CharacterController _controller;
    #endregion

    void LateUpdate()
    {
        if (!MariValues.PlayerIsTeleporting)
        {
            // kan be opdated to only count op if the player is not on groud. and reaste ind a defrint way

            // reastes the gravgig if the player is on solled ground
            MariValues.IsGrounded = Physics.CheckSphere(_mariLegs.position, _mariGravity.GroundDistance, _mariGravity.GroundMask);
            if (MariValues.IsGrounded == true && MariValues.Velocity.y < 0)
            {
                MariValues.Velocity.y = _mariGravity.DefaultGravity;
            }

            // poleds the player down and keaps bilding gravity. but the nummber gets reaset if player lands on ground
            MariValues.Velocity.y += MariValues.Gravity * Time.deltaTime;
            _controller.Move(MariValues.Velocity * Time.deltaTime);
        }
    }
}
