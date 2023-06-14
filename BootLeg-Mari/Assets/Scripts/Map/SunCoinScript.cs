
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunCoinScript : MonoBehaviour
{
    [SerializeField] GameObject _sunCoinOrder;
    [SerializeField] short _sunCoinNumber;

    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _sunCoinOrder.SetActive(true);
    }
}
