using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Enemy States")]
    [SerializeField] protected EnemyStatesSkripteabelObjects _enemyStates;
/*    [SerializeField] protected float _aggroRangeOfEnemy;
    [SerializeField] protected float _enemySpeed, _passeveSpeed;*/

    // torturial
    [Header("taget to thase")]
    [SerializeField] private EemyTargetScriptebolObject _enemyTargetScriptabelObject;
    [SerializeField] Transform TargetToMoveTo;
    private Collider[] _isWithIndAggroRange;
    

    // Update is called once per frame
    void Update()
    {
        EnemeyMovemet();
    }

    //Methodes
    #region

    // The enemy movment and is active or not
    #region
    /// <summary>
    /// Makes a cirkel around the enemy and if a thing ind player Layer enteres
    /// it goes ind to active mode. and if it does not then it is ind passive mode
    /// </summary>
    void EnemeyMovemet()
    {
        //Makes a shere around the enmey using the _aggroRangeOfEnemy to determen how big it has to be
        _isWithIndAggroRange = Physics.OverlapSphere(transform.position, _enemyStates._aggroRangeOfEnemy, _enemyTargetScriptabelObject.TargetsLayer);

        // keeps the enmey ind passe stands unless the player gets ind range of the enimy
        if (_isWithIndAggroRange.Length > 0)
        {
            // active stanes: is delperlitlig tring to kille the player. and will fx thase the player
            ActiveStands();
        }
        else
        {
            // passive stans: the ememy moves around and is not trying to kill the player
            PassiveStands();
        }
    }

    protected virtual void ActiveStands()
    {
        // makes the Gomba move towards the targets positon. with herer is the players positon
        transform.position = Vector3.MoveTowards(transform.position, TargetToMoveTo.position, _enemyStates._enemySpeed * Time.deltaTime);

        RotatoLookAtTarget(TargetToMoveTo);
    }

    protected virtual void PassiveStands() { }
    #endregion

    /// <summary>
    /// makes the enemy rotate so it lookes at the thing/spot it is moving to
    /// </summary>
    /// <param name="rotateToLookTo"></param>
    protected void RotatoLookAtTarget(Transform rotateToLookTo)
    {
        // gets the players position - the players y. withe here is the gombas y position
        Vector3 TargetPosisionExepetY = new Vector3(rotateToLookTo.position.x, transform.position.y, rotateToLookTo.position.z);

        // makes the enemy rotate to look towordes the player
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, TargetPosisionExepetY - transform.position, 3f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    // Killes the enemy if it is hit
    protected void EnemyHit()
    {
        Destroy(gameObject);
    }


    protected void AttackPlayer(Collider _other)
    {
        //
        if (_other.TryGetComponent<IIsHitebol>(out var hitebol) && !MariValues.MariIsDead)
        {
            Debug.Log("Gomba Hit Player");
            hitebol.ObjegtHasBenHit(1);
        }
    }
    #endregion
}
