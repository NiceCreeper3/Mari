using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour, IJumpable
{
    Transform GetTheYeelowBar;
    
    //the time it takes ontell it falls and the time it takes to reaset
    [SerializeField] float _timeOnTelItFalls , _timeOnTelItReasets;


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
        //Makes the yellow bar red
        GetTheYeelowBar.GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSecondsRealtime(_timeOnTelItFalls);
        PlatFormFall();

        yield return new WaitForSecondsRealtime(_timeOnTelItReasets);
        PlatFormReaset();
    }

    // makes the platform fall after a delley
    void PlatFormFall()
    {
        // mankes the platform Fall by removing isKinematic      
        Platform.isKinematic = false;
    }

    // reastes the platform to origenal position
    void PlatFormReaset()
    {
        //Makes the yellow bar yellow agien
        GetTheYeelowBar.GetComponent<Renderer>().material.color = Color.yellow;

        // mankes the platform stop falling by returning isKinematic. and it movees the platform to its origenal position
        Platform.isKinematic = true;
        gameObject.transform.position = new Vector3(_origanalPositon.x, _origanalPositon.y, _origanalPositon.z);
    }
}
