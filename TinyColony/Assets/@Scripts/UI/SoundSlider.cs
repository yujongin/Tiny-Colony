using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float bgmValue = PlayerPrefs.GetFloat("bgmValue",0.8f);
        float sfxValue = PlayerPrefs.GetFloat("sfxValue", 0.8f);

        bgmSlider.onValueChanged.AddListener(Managers.Sound.ControlBGMSound);
        sfxSlider.onValueChanged.AddListener(Managers.Sound.ControlSFXSound);

        bgmSlider.value = bgmValue;
        sfxSlider.value = sfxValue;
    }

}
