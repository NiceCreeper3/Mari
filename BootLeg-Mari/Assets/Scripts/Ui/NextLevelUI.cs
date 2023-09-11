using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] short _selecktScene;
    [SerializeField] string[] Scenes;

    private void Start()
    {
        Scenes[0] = "MaiMenu";
        Scenes[1] = "(Hop Skip Jump) map1";
        Scenes[2] = "(Wrong game) map2";
        Scenes[3] = "(Cold Sholder) map3";
        Scenes[4] = "(JumpInNameOfColor) map4";
        Scenes[5] = "(End Of All) Map5";
    }

    public void StartScene()
    {
        WorldValues.PlayerSpawnPoint = new Vector3(0, 3, 0);
        //Reasets score rikvaerments
        WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;
        SceneManager.LoadScene(Scenes[_selecktScene]);
    }


}
