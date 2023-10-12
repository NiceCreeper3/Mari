using System;
using System.Collections;
using UnityEngine;

public class CreatureHeadSkript : MonoBehaviour , IJumpable
{
    //Values
    #region
    // (Deturmens how fast chreatures head spines)
    [Header("Creautor head spin")]
    [SerializeField] private float _headSpinSpeed;
    private float _normalHeadSpinSpeed;

    [Header("head bash smoke")]
    [SerializeField] private float _howLongSmokeLastes;
    [SerializeField] private ParticleSystem _headBashSmoke;

    [Header("head bash indetatore")]
    [SerializeField] private float _howLongTheIndekatorWarns;
    [SerializeField] private Transform _headBashIndekator;

    [Header("Position to move and speed")]
    [SerializeField] private Transform _whereToMoveHead;
    [SerializeField] private float _headBashSpeed;
    private Vector3 _normalPositon;

    private bool _hasBeanHitReasentlig;

    public event Action BossIsHit;
    #endregion

    // Triggeres
    #region

    void Awake()
    {
        _normalHeadSpinSpeed = _headSpinSpeed;
        _normalPositon = transform.position;
    }

    void Update()
    {
        // rotates this gameObjet
        transform.Rotate(new Vector3(_headSpinSpeed, 0, _headSpinSpeed) * Time.deltaTime, Space.Self);
    }

    // Calls the head to preform a attack
    public void OnAttackTrigger(object data)
    {
        // makes it so the boss slams his head down into the ground
        StartCoroutine(HeadBashAttack());
    }

    // is called ones the player has jumpet on the boss
    public void JumpetOn(int hit)
    {
        if (!_hasBeanHitReasentlig)
        {
            _headSpinSpeed = _normalHeadSpinSpeed;

            // goves back to the orignal positon
            StartCoroutine(MoveToPointBFromA(_normalPositon));

            // calls that that the player has hit the head to boss script
            BossIsHit.Invoke();

            // makes it so the player does not hit the boss multebol times
            _hasBeanHitReasentlig = true;
            StartCoroutine(HitCoolDown());
        }
    }
    #endregion

    // methodes??
    #region
    private IEnumerator MoveToPointBFromA(Vector3 b)
    {
        while (transform.position != b)
        {
            yield return new WaitForSecondsRealtime(0);
            transform.position = Vector3.MoveTowards(transform.position, b, _headBashSpeed * Time.deltaTime);
        }
    }

    private IEnumerator HeadBashAttack()
    {
        // stopes the creatures head from spinnig
        _headSpinSpeed = 0;

        // shows Attack Indekattor
        _headBashIndekator.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);

        // makes it so the head stops spining. and reverets to normal rotation
        transform.eulerAngles = Vector3.zero;

        // moves the Creatures head down
        StartCoroutine(MoveToPointBFromA(_whereToMoveHead.position));

        // deploes somke to indkate a slam
        _headBashSmoke.Play();
        yield return new WaitForSecondsRealtime(_howLongSmokeLastes);

        // stopes the smoke and removes the indekator
        _headBashSmoke.Stop();
        _headBashIndekator.gameObject.SetActive(false);
    }

    private IEnumerator HitCoolDown()
    {
        yield return new WaitForSecondsRealtime(4);
        _hasBeanHitReasentlig = false;
    }
    #endregion
}
