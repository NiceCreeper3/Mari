using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaialScript : MonoBehaviour
{
    
    
    [SerializeField] private ParticleSystem _explosen;
    [SerializeField] private float _missailHight;
  
    private float _howLongExplosenLastes = 0.0001f;

    private Rigidbody _rb;
    private GameObject _landingSpot;

    private void Awake()
    {
        // Gets the Missales Rigidbody
        _rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, _missailHight, transform.position.z);

        //getes the landing Spot
        _landingSpot = transform.parent.GetChild(1).gameObject;
    }

    private void OnEnable()
    {   
        //Reasets the missaial
        _rb.isKinematic = false;
        transform.position = new Vector3(transform.position.x, _missailHight, transform.position.z);

        // activates the landing indekator
        _landingSpot.SetActive(true);
    }

    // turens of the landing indekatore hven the missail is deasbeld
    private void OnDisable()
    {
        _landingSpot.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // stopes the Missale
        _rb.isKinematic = true;
        StartCoroutine(Exploed());
    }


    IEnumerator Exploed()
    {
        // players the explsion 
        _explosen.Play();

        // waits a momment before it desiperes. otherways it does not have time to do damig to player
        yield return new WaitForSecondsRealtime(_howLongExplosenLastes);
        transform.gameObject.SetActive(false);
    }
}
