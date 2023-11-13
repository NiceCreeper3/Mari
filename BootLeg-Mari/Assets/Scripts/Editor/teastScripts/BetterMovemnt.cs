using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovemnt : MonoBehaviour
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


    private Vector3 _move;
    #endregion

    private void Awake()
    {
        // Get a refends to the Chareturecontroller
        _controller = GetComponent<CharacterController>();

        // inde i en coruten so scene har tid til at indlese Spawnpoint
        transform.position = WorldValues.PlayerSpawnPoint;

        // Sets the player to not be dead and that he is not on ice. inkase the player dies on ice
        MariValues.MariIsDead = MariValues.OnIcyFloor = false;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!MariValues.MariIsDead && !MariValues.PlayerIsTeleporting)
        {
            PlayerMoveIndPut();
        }
    }

    // methodes
    #region
    // brackys
    private void PlayerMoveIndPut()
    {
        // read inputs and gets W.A.S.D to move
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // gives where to move the player if not wall jumping
        if (!MariValues.IsWallJumping)
        {
            // the .normalize makes it so we don,t get extra speed by holding bofe buttons
            _move = new Vector3(x, 0f, z).normalized;
        }


        /// makes the player Move Forwert Continuislig if he is on ice.
        /// its is before normal movement so you dont wake and have normal speed
        if (MariValues.OnIcyFloor)
        {

            // moves the player
            MovePlayer(_move, mariMovmentStatesSB.SlideSpeed, true);
        }
        else if (_move.magnitude >= 0.1f) // moves the player if _move is a value that is move then  0.1f
        {
            // moves the player
            MovePlayer(_move, mariMovmentStatesSB.Speed, true);
            CreatSpeedDust();
        }

    }

    public void MovePlayer(Vector3 howToMove, float speed, bool combineWithCam)
    {
        // detuermens if you want to push the player with it takking the cammerra indto acoundt 
        if (combineWithCam)
        {
            Vector3 NormalCamMove = LookDependingOnCam(howToMove);
            // moves the player
            _controller.Move(NormalCamMove.normalized * speed * Time.deltaTime);
        }
        else
        {
            // moves the player
            _controller.Move(howToMove.normalized * speed * Time.deltaTime);
        }


        /*
                if (MariValues.ForsMovePlayer.magnitude >= 0.1f) // moves the player if you pushe down WASD
                {
                    // detuermens if you want to push the player with it takking the cammerra indto acoundt 
                    if (pushDependingOnCam)
                    {
                        Vector3 NormalCamMove = LookDependingOnCam(MariValues.ForsMovePlayer);
                        // moves the player
                        _controller.Move(NormalCamMove.normalized * speed * Time.deltaTime);
                    }
                    else
                    {
                        // moves the player
                        _controller.Move(howToMove * mariMovmentStatesSB.Speed * Time.deltaTime);
                    }
                }*/
    }


    // makes Mari rotate and wake in acodens to the cammara
    private Vector3 LookDependingOnCam(Vector3 moveGiven)
    {
        // makes Mari curkel and wake ind akottens to cam
        float targetAngel = Mathf.Atan2(moveGiven.x, moveGiven.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

        // rotates the player atording to the cammara
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
