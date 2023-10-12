using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBall : MonoBehaviour
{
    #region
    [Header("deturmens at what stage the Shere kan be activeted")]
    [SerializeField] private ushort _activatsAtStage;

    [Header("How long the DoomShere is active and will chase the player")]
    [SerializeField] private ushort _fourHowLongItsAttive;

    [Header("Shere Speed")]
    [SerializeField] private float _speed;

    [Header("referenses")]
    [SerializeField] private Transform _targetToChase;
    
    private bool _isAttive = false;

    // the axis the 1 stage movment uses to only move on one axis
    private Vector3 chaseOnXYZ;

    // the origanal start posison the Shere had
    private Vector3 _origenalPosition;
    private Transform _orbLook;

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        // gets the shere 
        _orbLook = transform.GetChild(0);

        //Gets the DoomSheres origanl position
        _origenalPosition = transform.position;
    }

    /// if event is called it turens on the apprens so player can see it
    /// and then alows it self to chase the player
    /// it also starts the ChaseTime IEnumerator withe after som time reasets the DoomShere
    public void ActivateDoomSheres(object data)
    {
        ushort attackStage = (ushort)data;
        Debug.Log(attackStage);

        // checks if the boss stage is the same or higher then _activatsAtStage if yeas then the Doom shere is set active and begens to chase the player
        if (_activatsAtStage <= attackStage)
        {
            StartCoroutine(ChaseTime());
        }
    }

    private void LateUpdate()
    {
        // moves it it is active
        if (_isAttive)
        {
            //Gives defrint ways to chase player depending on what stage the shere is active
            switch (_activatsAtStage)
            {
                // moves to words the player but only on 1 axis at a time
                case 1:
                    StupidMovmment();                   
                    break;

                // Chases player but wil over shoot
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, _targetToChase.position * 1.5f, _speed * Time.deltaTime);
                    break;

                // flyes derektlig to player
                case 3:
                    
                    transform.position = Vector3.MoveTowards(transform.position, _targetToChase.position, _speed * Time.deltaTime);
                    break;
            }
        }
    }

    void StupidMovmment()
    {   
        // makes it so the Veture 3 that the shere uses to thase the player only knows of one axis at a time with it goving ind the order of XYZ
        if (transform.position.x != _targetToChase.position.x)
        {
            chaseOnXYZ = new Vector3(_targetToChase.position.x, transform.position.y, transform.position.z);
        }

        else if (transform.position.y != _targetToChase.position.y)
        {
            chaseOnXYZ = new Vector3(transform.position.x, _targetToChase.position.y, transform.position.z);
        }

        else if (transform.position.z != _targetToChase.position.z)
        {
            chaseOnXYZ = new Vector3(transform.position.x, transform.position.y, _targetToChase.position.z);
        }

        // moves using the chaseOnXYZ. with makes it so the Shere only moves on one axis at a time
        transform.position = Vector3.MoveTowards(transform.position, chaseOnXYZ, _speed * Time.deltaTime);
    }

    /// <summary>
    /// deturmens four how long the Sheres are alowed to chase player
    /// and when that time runds out the sheres positon gets reaset
    /// the time the sheres have is deturment by the _fourHowLongItsAttive valube
    /// </summary>
    private IEnumerator ChaseTime()
    {
        // turns on the DoomShere
        _isAttive = true;
        _orbLook.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(_fourHowLongItsAttive);

        // turns off the DoomShere
        _orbLook.gameObject.SetActive(false);
        _isAttive = false;

        // and reasets the position of the DoomShere
        transform.position = _origenalPosition;
    }
}
