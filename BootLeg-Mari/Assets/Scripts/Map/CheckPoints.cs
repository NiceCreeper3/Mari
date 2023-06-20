using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [Header("Color of Falg as it is takken")]
    [SerializeField] Material _flagTakkenColor;

    [Header("Checks if we got coin and reambes it")]

    [SerializeField] GameObject _sunCoinFiled1, _sunCoinFiled2, _sunCoinFiled3;

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

    // sets Maris new spawnpoint and saves info
    void SetNewSpawnPoint()
    {
        if (!_hasBenAktivated)
        {
            Debug.Log("Player has new Spawn");
            WorldValues.PlayerSpawnPoint = transform.position;

            //StartCoroutine(ReamberSunCoin());
            ReamberSunCoin1();

            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;
            _hasBenAktivated = true;
        }
    }

    IEnumerator ReamberSunCoin()
    {
        // gives controll bak to player after som time has passed
        yield return new WaitForSecondsRealtime(0.3f);

        // reambers if we have gotten the SunCoin wen vi hit the check point
        if (_sunCoinFiled1.activeSelf)
            WorldValues.SunCoinNummber1 = true;
        if (_sunCoinFiled2.activeSelf)
            WorldValues.SunCoinNummber2 = true;
        if (_sunCoinFiled3.activeSelf)
            WorldValues.SunCoinNummber3 = true;
    }

    void ReamberSunCoin1()
    {
        // reambers if we have gotten the SunCoin wen vi hit the check point
        if (_sunCoinFiled1.activeSelf)
            WorldValues.SunCoinNummber1 = true;
        if (_sunCoinFiled2.activeSelf)
            WorldValues.SunCoinNummber2 = true;
        if (_sunCoinFiled3.activeSelf)
            WorldValues.SunCoinNummber3 = true;
    }

}
