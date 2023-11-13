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
    [SerializeField] private CharacterController _controller;

    // <camara>
    [Header("Camerra")]
    [SerializeField] private Transform _cam;

    // <turning>
    private float _turnSmoothVelosetig;

    [Header("Partikal efekt")]
    [SerializeField] ParticleSystem _runCloud;
    #endregion

    private void Awake()
    {
        // Get a refends to the Chareturecontroller
        _controller = GetComponent<CharacterController>();

        // if the player has got a check point then there will spawn there
        if (WorldValues.HasGotCheckPoint)
        {
            StartCoroutine(WaitASec());
        }


        // Sets the player to not be dead and that he is not on ice. inkase the player dies on ice
        MariValues.MariIsDead = MariValues.OnIcyFloor = false;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!MariValues.MariIsDead && !MariValues.PlayerIsTeleporting)
        {
            MariMovement();
        }
    }

    private void MariMovement()
    {
        // read inputs and gets W.A.S.D to move
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (!MariValues.IsWallJumping)
        {
            // the .normalize makes it so we don,t get extra speed by holding bofe buttons
            MariValues.ForsMovePlayer = new Vector3(x, 0f, z).normalized;
        }

        /// makes the player Move Forvert Continuislig if he is on ice.
        /// its is before normal movement so you dont wake and have normal speed
        if (MariValues.OnIcyFloor)
        {
            Vector3 moveDir = LookDependingOnCam();

            // moves the player
            _controller.Move(moveDir.normalized * mariMovmentStatesSB.SlideSpeed * Time.deltaTime);
        }
        else if (MariValues.ForsMovePlayer.magnitude >= 0.1f) // moves the player if you pushe down WASD
        {
            Vector3 NormalCamMove = LookDependingOnCam();
            // moves the player
            _controller.Move(NormalCamMove.normalized * mariMovmentStatesSB.Speed * Time.deltaTime);

            CreatSpeedDust();
        }

    }


    // makes Mari rotate and wake in acodens to the cammara
    private Vector3 LookDependingOnCam()
    {
        // makes Mari curkel and wake ind akottens to cam
        float targetAngel = Mathf.Atan2(MariValues.ForsMovePlayer.x, MariValues.ForsMovePlayer.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

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

    private IEnumerator WaitASec() 
    {
        MariValues.PlayerIsTeleporting = true;

        yield return null;

        transform.position = WorldValues.PlayerSpawnPoint;
        Debug.Log("Player spawn point is " + WorldValues.PlayerSpawnPoint);

        yield return null;
        MariValues.PlayerIsTeleporting = false;
    }
}