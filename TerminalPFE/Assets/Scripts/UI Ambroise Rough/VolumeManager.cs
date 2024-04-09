using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    //public AkAudioListener camAudioListener;

    

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

    private void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        //AudioListener.volume = volumeSlider.value;
        AkSoundEngine.SetRTPCValue("VOLUME", volumeSlider.value * 100);
        SaveVolume();
    }

    public void MuteVolume()
    {
        volumeSlider.value = 0f;
        SaveVolume();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
