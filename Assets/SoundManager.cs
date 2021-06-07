using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MainMusic;
    public AudioSource BtnSound;
    public AudioSource SoundEffect;

    public void SetMusicVolume(float volume)
    {
        MainMusic.volume = volume;
    }

    public void SetBtnVolume(float volume)
    {
        BtnSound.volume = volume;
    }
    public void SetSoundEffect(float volume)
    {
        SoundEffect.volume = volume;
    }

    public void OnSfx()
    {
        BtnSound.Play();
    }
}
