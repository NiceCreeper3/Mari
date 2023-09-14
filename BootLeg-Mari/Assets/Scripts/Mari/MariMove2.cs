using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MariMove2 : MonoBehaviour
{
    // values
    #region

    [SerializeField] private MariMovmentStatesSB mariMovmentStatesSB;

    // <movment>
    [Header("Movment")]
    [SerializeField] CharacterController _controller;

    // <camara>
    [Header("Camerra")]
    [SerializeField] Transform _cam;

    // <turning>
    private float _turnSmoothVelosetig;

    [Header("Partikal efekt")]
    [SerializeField] ParticleSystem _runCloud;
    #endregion

    private void Awake()
    {
        // inde i en coruten so scene har tid til at indlese Spawnpoint
        transform.position = WorldValues.PlayerSpawnPoint;

        // Sets the player to not be dead and that he is not on ice. inkase the player dies on ice
        MariValues.MariIsDead = MariValues.OnIcyFloor = false;
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
            _controller.Move(moveDir.normalized * mariMovmentStatesSB.SlideSpeed * Time.deltaTime);
        }
        else if (MariValues.Move.magnitude >= 0.1f) // moves the player if you pushe down WASD
        {
            Vector3 NormalCamMove = LookDependingOnCam();
            // moves the player
            _controller.Move(NormalCamMove.normalized * mariMovmentStatesSB.Speed * Time.deltaTime);
        }
    }


    // makes Mari rotate and wake in acodens to the cammara
    Vector3 LookDependingOnCam()
    {
        // makes Mari curkel and wake ind akottens to cam
        float targetAngel = Mathf.Atan2(MariValues.Move.x, MariValues.Move.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref _turnSmoothVelosetig, mariMovmentStatesSB.TurnSmoothTime);
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