using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;

    public AudioClip titleBGM;
    public AudioClip gameBGM;
    public AudioClip buttonHoverSound;
    public AudioClip explodeSound;
    public AudioClip portalSound;

    private void Awake()
    {
        BGM.volume = PlayerPrefs.GetFloat("bgmValue", 0.8f);
        SFX.volume = PlayerPrefs.GetFloat("sfxValue", 0.8f);
    }

    public void PlayOneShot(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }

    public void ControlBGMSound(float value) 
    {
        BGM.volume = value;
        PlayerPrefs.SetFloat("bgmValue", value);
    }
    public void ControlSFXSound(float value)
    {
        SFX.volume = value;
        PlayerPrefs.SetFloat("sfxValue", value);
    }
}
