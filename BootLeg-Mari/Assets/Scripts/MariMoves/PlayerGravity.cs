using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] float _groundDistance = 0.4f;

    [SerializeField] LayerMask _groundMask;
    [SerializeField] Transform _mariLegs;

    // can maby remove
    [SerializeField] CharacterController _controller;

    #region Shared 
    /// <summary>
    /// is shared with
    /// MariMove2
    /// Jump
    /// </summary>

    // determans if we are grounden
    public static bool _isGrounded;

    public static Vector3 _velocity;
    public static float _gravity = -10;
    #endregion

    void LateUpdate()
    {
        _isGrounded = Physics.CheckSphere(_mariLegs.position, _groundDistance, _groundMask);
        if (_isGrounded == true && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
