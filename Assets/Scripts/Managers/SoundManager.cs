// 5.b. Ajouter des bruitages

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    #region Singleton
    static SoundManager m_instance;
    static public SoundManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
        sounds = GetComponents<AudioSource> ();
    }
    #endregion

    private AudioSource[] sounds;

    public void PlaySound (string soundName) {
        switch (soundName) {
            case "Main Menu":
                sounds[0].Play ();
                break;
            case "World 1":
                sounds[1].Play ();
                break;
            case "World 2":
                sounds[2].Play ();
                break;
            case "World 3":
                sounds[3].Play ();
                break;
            case "World 4":
                sounds[4].Play ();
                break;
            case "Charge":
                sounds[5].Play ();
                break;
            case "Shoot":
                sounds[6].Play ();
                break;
            case "Jump":
                sounds[7].Play ();
                break;
            case "Death":
                sounds[8].Play ();
                break;
        }
    }

    public void StopSound (string soundName) {
        switch (soundName) {
            case "Main Menu":
                sounds[0].Stop ();
                break;
            case "World 1":
                sounds[1].Stop ();
                break;
            case "World 2":
                sounds[2].Stop ();
                break;
            case "World 3":
                sounds[3].Stop ();
                break;
            case "World 4":
                sounds[4].Stop ();
                break;
            case "Charge":
                sounds[5].Stop ();
                break;
            case "Shoot":
                sounds[6].Stop ();
                break;
            case "Jump":
                sounds[7].Stop ();
                break;
            case "Death":
                sounds[8].Stop ();
                break;
        }
    }
}

// Fin 5.b