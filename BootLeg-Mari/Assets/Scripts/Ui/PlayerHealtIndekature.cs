using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtIndekature : MonoBehaviour
{
    [SerializeField] private MariHealtScriptebolObjeckt _howMotheHealtThePlayerHas;

    [SerializeField] private List<GameObject> _playerHealtImges = new List<GameObject>();

    private void Start()
    {
        // filles the _playerHealtImges list
        foreach (Transform imges in transform)
            _playerHealtImges.Add(imges.gameObject);

        // geats the first Imge to be showen wich here is full hp
        ChangePlayerHealt();
    }

    public void PlayerHealtChange(object data)
    {
        ChangePlayerHealt();
    }

    private void ChangePlayerHealt()
    {
        // reasets all the imegis
        foreach (GameObject turnOff in _playerHealtImges)
                    turnOff.SetActive(false);

        // sets the playeres healt img atording to the healt the player has left
        // onlesh the playeres healt is under 0 ind withe chase it defalts to 0 aka the last img
        if (_howMotheHealtThePlayerHas.PlayerCurrentHealt > 0)
            _playerHealtImges[_howMotheHealtThePlayerHas.PlayerCurrentHealt].SetActive(true);
        else
            _playerHealtImges[0].SetActive(true);
    }
}