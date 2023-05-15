using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour, IJumpable
{
    Transform GetTheYeelowBar;
    [SerializeField] int _timeOnTelItReasets;
    Vector3 _origanalPositon;
    Rigidbody Platform;


    void Start()
    {
        // gets the platfrom positoin and Rigidbody
        _origanalPositon = transform.position;
        Platform = GetComponent<Rigidbody>();

        GetTheYeelowBar = gameObject.transform.GetChild(0);
    }

    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("Platform hit");

        // makes the platform fall and go op aigen
        StartCoroutine(MakeBarFall());
    }

    IEnumerator MakeBarFall()
    {
        yield return null;
        PlatFormFall();

        yield return new WaitForSecondsRealtime(_timeOnTelItReasets);
        PlatFormReaset();

    }

    void PlatFormFall()
    {
        //Makes the yellow bar red
        GetTheYeelowBar.GetComponent<Renderer>().material.color = Color.red;

        // mankes the platform Fall by removing isKinematic
        Platform.isKinematic = false;
    }

    void PlatFormReaset()
    {
        //Makes the yellow bar yellow agien
        GetTheYeelowBar.GetComponent<Renderer>().material.color = Color.yellow;

        // mankes the platform stop falling by returning isKinematic. and it movees the platform to its origenal position
        Platform.isKinematic = true;
        gameObject.transform.position = new Vector3(_origanalPositon.x, _origanalPositon.y, _origanalPositon.z);
    }
}
