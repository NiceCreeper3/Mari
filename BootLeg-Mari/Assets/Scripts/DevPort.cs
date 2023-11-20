using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPort : MonoBehaviour
{
    private List<Transform> telspots = new List<Transform>();
    [SerializeField] private GameObject mari;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform telPorsisons in transform)
        {
            telspots.Add(telPorsisons);
        }
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetButtonDown("g"))
        {
            MariValues.PlayerIsTeleporting = true;
        }
        if (Input.GetButtonDown("h"))
        {
            MariValues.PlayerIsTeleporting = false;
        }

        if (Input.GetButtonDown("1"))
        {
            mari.transform.position = telspots[0].position;
        }
        if (Input.GetButtonDown("2"))
        {
            mari.transform.position = telspots[1].position;
        }
        if (Input.GetButtonDown("3"))
        {
            mari.transform.position = telspots[2].position;
        }
        if (Input.GetButtonDown("4"))
        {
            mari.transform.position = telspots[3].position;
        }
        if (Input.GetButtonDown("5"))
        {
            mari.transform.position = telspots[4].position;
        }*/


    }
}
