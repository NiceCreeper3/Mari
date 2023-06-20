
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunCoinScript : MonoBehaviour
{
    [SerializeField] GameObject _sunCoinOrder;
    [Range(1, 3)]
    [SerializeField] short _sunCoinNumber;


    private void Awake()
    {
        if (WorldValues.SunCoinNummber1 && _sunCoinNumber == 1)
        {
            CoinHasBeanTaken();
        }
        else if (WorldValues.SunCoinNummber2 && _sunCoinNumber == 2)
        {
            CoinHasBeanTaken();
        }
        else if (WorldValues.SunCoinNummber2 && _sunCoinNumber == 2)
        {
            CoinHasBeanTaken();
        }
    }

    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        GotSunCoin();
    }

    // set the info of getting coin
    private void GotSunCoin()
    {
        WorldValues.ScoreSunCoinsColleted += 1;
        _sunCoinOrder.SetActive(true);
        Destroy(gameObject);
    }

    private void CoinHasBeanTaken()
    {
        Destroy(gameObject);
        _sunCoinOrder.SetActive(true);
    }
}
