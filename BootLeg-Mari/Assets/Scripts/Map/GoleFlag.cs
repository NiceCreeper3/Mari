using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoleFlag : MonoBehaviour
{
    [SerializeField] GameObject _winUi;
    private void OnTriggerEnter(Collider other)
    {
        _winUi.SetActive(true);
    }
}
