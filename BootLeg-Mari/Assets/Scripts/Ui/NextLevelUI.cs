using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] short NextLevel;
    public void StartLeve()
    {
        WorldValues.PlayerSpawnPoint = new Vector3(0, 3, 0);

        if (NextLevel == 1)
            SceneManager.LoadScene("MariMap");
        if (NextLevel == 2)
            SceneManager.LoadScene("(Rong game) map2");
        if (NextLevel == 3)
            SceneManager.LoadScene("Cold Sholder map3");
    }
}
