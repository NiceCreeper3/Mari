using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMissal : MonoBehaviour
{
    [Header("time it takes before doveing the next acson")]
    [SerializeField] private float _timeSmokeLastes;
    [SerializeField] private float _timeToGetBackMissal;

    [Header("deturmens if it is alowed to work ind stage 1 or stage 2 and above")]
    [SerializeField] private bool IsStage2Exklusive;

    [Header("refrensens")]
    [SerializeField] private ParticleSystem _lantheSmoke;
    //[SerializeField] private LinkedList<GameObject> _missalsLinkedList = new LinkedList<GameObject>();
    [SerializeField] private GameObject[] _missalsArray;


    public void RotateArms(object data)
    {
        // gets and converts the data to a usebol nummber
        ushort Stage = (ushort)data;

        // makes is 
        if (!IsStage2Exklusive || Stage >= 2)
            StartCoroutine(RorateArm());
    }


    private IEnumerator RorateArm()
    {
        /*
        // have no ider why it does not work??? 
        while (transform.rotation.x !<= 90)
        {   
            transform.Rotate(0.5f, 0, 0, Space.Self);
            yield return new WaitForSecondsRealtime(_rotasonSpeed);
        }*/

        // fire the Missals
        #region
        // rotates the arm 90 on the x axis
        for (int i = 0; i <= 45; i++)
        {
            transform.Rotate(2f, 0, 0, Space.Self);
            yield return new WaitForSecondsRealtime(0);
        }

        // removes the missails
        foreach (GameObject missail in _missalsArray)
        {
            missail.SetActive(false);
        }

        _lantheSmoke.Play();
        #endregion

        yield return new WaitForSecondsRealtime(_timeSmokeLastes);

        // reasets the arm
        #region
        _lantheSmoke.Stop();

        // rotates the arm down agien
        for (int i = 0; i <= 90; i++)
        {
            transform.Rotate(-1f, 0, 0, Space.Self);
            yield return new WaitForSecondsRealtime(0);
        }

        yield return new WaitForSecondsRealtime(_timeToGetBackMissal);

        // reasets the missails
        foreach (GameObject missail in _missalsArray)
        {
            missail.SetActive(true);
        }
        #endregion 
    }
}
