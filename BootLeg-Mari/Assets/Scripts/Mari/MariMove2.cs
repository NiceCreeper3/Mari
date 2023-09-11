using System.Collections;
using System.Collections.Generic;
using System;
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
    float _turnSmoothVelosetig;

    [Header("ice is workind progres")]
    [SerializeField] private float _SlideSpeed;

    [Header("Partikal efekt")]
    [SerializeField] ParticleSystem _runCloud;


    /*
        [SerializeField] private float _slideStartSpeed;
        [SerializeField] private float _slideTime;
        private float slippyMoveSpeed;
    */
    #endregion

    private Action _mariMovementFuncstion;

    private void Awake()
    {
        MariValues.Health = 3;
        MariValues.MariIsDead = false;
        MariValues.OnIcyFloor = false;

        // inde i en coruten so scene har tid til at indlese Spawnpoint
        transform.position = WorldValues.PlayerSpawnPoint;
        _mariMovementFuncstion = NormalMoveMent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!MariValues.MariIsDead && !MariValues.PlayerIsTeleporting)
        {
            MariMovement();
        }

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

        /// makes the player Move Forvert Continuislig if he is on ice.
        /// its is before normal movement so you dont wake and have normal speed
        if (MariValues.OnIcyFloor)
        {
            Vector3 moveDir = LookDependingOnCam();

            // moves the player
            _controller.Move(moveDir.normalized * _SlideSpeed * Time.deltaTime);
        }
        else if (MariValues.Move.magnitude >= 0.1f) // moves the player if you pushe down WASD
        {
            Vector3 NormalCamMove = LookDependingOnCam();
            // moves the player
            _controller.Move(NormalCamMove.normalized * _speed * Time.deltaTime);
        }
    }

    private void IcyMovment()
    {

    }

    private void NormalMoveMent()
    {

    }



    // makes Mari Rotate to wake akording to the cammera
    Vector3 LookDependingOnCam()
    {
        // makes Mari curkel and wake ind akottens to cam
        float targetAngel = Mathf.Atan2(MariValues.Move.x, MariValues.Move.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref _turnSmoothVelosetig, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

        return moveDir;
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




