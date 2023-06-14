using UnityEngine;



[System.Serializable]
public class AudipSound
{
    public string Name;

    public AudioClip Clip;

    // Info on how the Audio sjode be played
    [Header("Volume Settings")]
    [Range(0f, 1f)] public float Volune;
    [Range(0f, 3f)] public float Pitch;

    public bool LoopAudio;

    [HideInInspector]
    public AudioSource Source;
}
