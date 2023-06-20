using UnityEngine;

public class WorldValues
{
    /// Is the point the player vil spawn
    /// Origen: MariDead
    /// Is linked: MariDead, MariMove2    
    public static Vector3 PlayerSpawnPoint = new Vector3(0, 3, 0);

    /// ville show if player has dide. and wille afekt score
    /// Origen: MariDead
    /// Is linked: MariDead, GoleFlag    
    public static bool ScoreHasPlayerDied = false;

    /// ville show how many suncoins the player has colletet
    /// Origen: MariDead
    /// Is linked: SunCoinScript, GoleFlag    
    public static short ScoreSunCoinsColleted = 0;

    [Range(0, 3)]
    public static short SavedSuncoins = 0;

    public static bool SunCoinNummber1 = false, SunCoinNummber2 = false, SunCoinNummber3 = false;

}
