using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour, IJumpable
{
    Transform GetTheYeelowBar;


    // Start is called before the first frame update
    void Start()
    {


        // does not work. tester migth be broken
        //GetTheYeelowBar.GetComponent<Renderer>().material.color = new Color(192, 41, 41);
    }

    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("Platform hit");

        GetTheYeelowBar = this.gameObject.transform.GetChild(0);
        GetTheYeelowBar.GetComponent<Renderer>().material.color = Color.red;



    }

    IEnumerable MakeBarFall()
    {
        yield return (1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
