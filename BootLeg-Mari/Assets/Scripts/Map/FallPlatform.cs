using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour, IJumpable
{
    Transform GetTheYeelowBar;

    [Header("Color Of Platform")]
    [SerializeField] Material _normalColor;
    [SerializeField] Material _fallColor;   

    //the time it takes ontell it falls and the time it takes to reaset
    [SerializeField] float _timeOnTelItFalls , _timeOnTelItReasets;

    //This just makes it so the audio donsent spam
    private bool HasBenJumpetOn = false;


    Vector3 _origanalPositon;
    Rigidbody _platform;


    void Start()
    {
        // gets the platfrom positoin and Rigidbody
        _origanalPositon = transform.position;
        _platform = GetComponent<Rigidbody>();

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
        GetTheYeelowBar.GetComponent<Renderer>().material.color = _fallColor.color;

        // playes audio det first time the platfom is hit
        if (!HasBenJumpetOn)
        {
            FindObjectOfType<AudioMangerScript>().PlayAudio("FallPlatFormDrope", true);
            HasBenJumpetOn = true;
        }

        yield return new WaitForSecondsRealtime(_timeOnTelItFalls);
        PlatFormFall();

        yield return new WaitForSecondsRealtime(_timeOnTelItReasets);
        PlatFormReaset();
    }

    // makes the platform fall after a delley
    void PlatFormFall()
    {
        // mankes the platform Fall by removing isKinematic      
        _platform.isKinematic = false;
    }

    // reastes the platform to origenal position
    void PlatFormReaset()
    {
        //Makes the yellow bar yellow agien
        GetTheYeelowBar.GetComponent<Renderer>().material.color = _normalColor.color;

        // allows audio to be played agien
        HasBenJumpetOn = false;

        // mankes the platform stop falling by returning isKinematic. and it movees the platform to its origenal position
        _platform.isKinematic = true;
        gameObject.transform.position = new Vector3(_origanalPositon.x, _origanalPositon.y, _origanalPositon.z);
    }
}
