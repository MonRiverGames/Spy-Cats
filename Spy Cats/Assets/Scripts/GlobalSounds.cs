using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSounds : MonoBehaviour
{
    public AudioSource jumpSoundSource;
    [HideInInspector]
    public static GlobalSounds instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayJumpSound() {
        if (!instance || instance.jumpSoundSource.isPlaying)
            return;
        instance.jumpSoundSource.Play();
    }
}
