using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariMove2 : MonoBehaviour
{
    // values
    #region
    // <movment>
    [Header("Movment")]
    [SerializeField] float _speed;
    [SerializeField] CharacterController _controller;

    // <camara>
    [Header("Camerra")]
    [SerializeField] Transform _cam;

    // <turning>
    [Header("Turning the Player")]
    [SerializeField] float _turnSmoothTime = 0.1f;
    [SerializeField] float _turnSmoothVelosetig;

    [SerializeField] ParticleSystem _runCloud;
    #endregion

    private void Start()
    {
        transform.position = WorldValues.PlayerSpawnPoint;

        MariValues.Health = 3;
        MariValues.MariIsDead = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!MariValues.MariIsDead && !MariValues.PlayerIsTeleporting)
        {
            MariMovement();
        }
        //StartCoroutine(CreatSpeedDust());
    }

    // methodes
    #region
    // brackys
    void MariMovement()
    {
        // read inputs and gets W.A.S.D to move
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (!MariValues.IsWallJumping)
        {
            CreatSpeedDust();
            // the .normalize makes it so we don,t get extra speed by holding bofe buttons
            MariValues.Move = new Vector3(x, 0f, z).normalized;

        }

        // makes Mari Rotate to wake akording to the cammera
        if (MariValues.Move.magnitude >= 0.1f)
        {
            // makes Mari curkel and wake ind akottens to cam
            float targetAngel = Mathf.Atan2(MariValues.Move.x, MariValues.Move.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref _turnSmoothVelosetig, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

            // moves the player
            _controller.Move(moveDir.normalized * _speed * Time.deltaTime);
        }
    }

    void CreatSpeedDust()
    {
        if (MariValues.IsGrounded)
        {
            _runCloud.Play();
        }
    }
    #endregion




}
