using UnityEngine;

public class WorldValues
{
    /// Is the point the player vil spawn
    /// Origen: MariDead
    /// Is linked: MariDead, MariMove2    
    public static Vector3 PlayerSpawnPoint;

    //deturmens if the player has goten the checkpoint
    public static bool HasGotCheckPoint = false;

    /// ville show if player has dide. and wille afekt score
    /// Origen: MariDead
    /// Is linked: MariDead, GoleFlag    
    public static bool ScoreHasPlayerDied = false;

    /// represends how meany suncoins the player has right now
    /// Origen: MariDead
    /// Is linked: SunCoinScript, GoleFlag    
    public static short CurrentSunCoins = 0;

    [Range(0, 3)]
    public static short SavedSunCoins = 0;

    // reapresends the spisifik suncoin
    public static bool SunCoinNummber1 = false, SunCoinNummber2 = false, SunCoinNummber3 = false;

}
