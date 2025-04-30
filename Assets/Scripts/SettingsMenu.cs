using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Load saved values and set sliders
        if (MusicManager.Instance != null)
        {
            musicSlider.value = MusicManager.Instance.GetVolume();
            musicSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        }

        sfxSlider.value = AudioSettingsManager.SFXVolume;
        sfxSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChange(); });
    }

    public void OnMusicVolumeChange()
    {
        MusicManager.Instance.SetVolume(musicSlider.value);
    }

    public void OnSFXVolumeChange()
    {
        AudioSettingsManager.SFXVolume = sfxSlider.value;
    }
}
