using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [Header("Color of Falg as it is takken")]
    [SerializeField] Material _flagTakkenColor;


    private Transform CheckPointFlag;
    private bool _hasBenAktivated = false;

    private void Awake()
    {
        //CheckPointPosition = gameObject.transform.position;
        CheckPointFlag = gameObject.transform.GetChild(0);
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("New Spawn");
            SetNewSpawnPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SetNewSpawnPoint();
    }

    void SetNewSpawnPoint()
    {
        if (!_hasBenAktivated)
        {
            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;
            WorldValues.PlayerSpawnPoint = transform.position;
            _hasBenAktivated = true;
        }
    }
}
