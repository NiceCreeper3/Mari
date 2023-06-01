using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] float _groundDistance = 0.4f;

    [SerializeField] LayerMask _groundMask;
    [SerializeField] Transform _mariLegs;

    // can maby remove
    [SerializeField] CharacterController _controller;

    void LateUpdate()
    {
        // kan be opdated to only count op if the player is not on groud. and reaste ind a defrint way

        // reastes the gravgig if the player is on solled ground
        MariValues.IsGrounded = Physics.CheckSphere(_mariLegs.position, _groundDistance, _groundMask);
        if (MariValues.IsGrounded == true && MariValues.Velocity.y < 0)
        {
            MariValues.Velocity.y = -2f;
        }

        // poleds the player down and keaps bilding gravity. but the nummber gets reaset if player lands on ground
        MariValues.Velocity.y += MariValues.Gravity * Time.deltaTime;
        _controller.Move(MariValues.Velocity * Time.deltaTime);
    }
}
