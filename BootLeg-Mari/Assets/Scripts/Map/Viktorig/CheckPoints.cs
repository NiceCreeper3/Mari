using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [Header("Color of Falg as it is takken")]
    [SerializeField] Material _flagTakkenColor;

    [Header("Checks if we got coin and reambes it")]
    [SerializeField] GameObject _sunCoinFiled1, _sunCoinFiled2, _sunCoinFiled3;

    private Transform CheckPointFlag;


    private void Awake()
    {
        //CheckPointPosition = gameObject.transform.position;
        CheckPointFlag = gameObject.transform.GetChild(0);
        if (WorldValues.HasGotCheckPoint)
            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        SetNewSpawnPoint();
    }

    // sets Maris new spawnpoint and saves info
    void SetNewSpawnPoint()
    {
        if (!WorldValues.HasGotCheckPoint)
        {
            Debug.Log("Player has new Spawn");
            WorldValues.PlayerSpawnPoint = transform.position;

            //StartCoroutine(ReamberSunCoin());
            ReamberSunCoins();

            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;
            WorldValues.HasGotCheckPoint = true;
            FindObjectOfType<AudioMangerScript>().PlayAudio("CheckPonintGot", true);
        }
    }

    void ReamberSunCoins()
    {
        WorldValues.SavedSuncoins = WorldValues.ScoreSunCoinsColleted;

        // reambers if we have gotten the SunCoin wen vi hit the check point
        if (_sunCoinFiled1.activeSelf)
            WorldValues.SunCoinNummber1 = true;
        if (_sunCoinFiled2.activeSelf)
            WorldValues.SunCoinNummber2 = true;
        if (_sunCoinFiled3.activeSelf)
            WorldValues.SunCoinNummber3 = true;
    }

}
