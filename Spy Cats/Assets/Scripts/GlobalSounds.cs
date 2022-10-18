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

    public void PlayJumpSound() {
        if (jumpSoundSource.isPlaying)
            return;
        jumpSoundSource.Play();
    }
}
