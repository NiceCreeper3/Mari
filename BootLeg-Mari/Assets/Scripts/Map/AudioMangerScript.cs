using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioMangerScript : MonoBehaviour
{
    [SerializeField] AudipSound[] _sounds;

    private static AudioMangerScript instance;   
    // Start is called before the first frame update
    void Awake()
    {
        // Singelten
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // makes it so the script does not delete on scene load. dis is don so audio does not get cut off
        DontDestroyOnLoad(gameObject);

        // makes a AudioSource commponent withe set Settings
        foreach (AudipSound s in _sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volune;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.LoopAudio;
        }
    }

    /// <summary>
    /// uses the given settings and playes or turn of a audio sampel
    /// 
    /// Code to play audio
    /// FindObjectOfType<AudioMangerScript>().PlayAudio("", true);
    /// </summary>
    /// <param name="name"> the name of audio we want to play </param>
    /// <param name="playAudio"> deturmens if we want to play or stop audio </param>
    public void PlayAudio(string name, bool playAudio)
    {
        //gets the Audio by name
        AudipSound s = Array.Find(_sounds, AudipSound => AudipSound.Name == name);

        // checks if the kode favnt the audio. and if it dident then it stopes the code and gives a error messege
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found. check if the name give is correckt");
            return;
        }
        
        if(playAudio)
            s.Source.Play();
        else
            s.Source.Stop();


    }
}
