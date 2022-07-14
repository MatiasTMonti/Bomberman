using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;

    private string volume = "volume";
    private float musicVolume = 1f;


    private void Awake()
    {
        SaveDataMute();
    }

    void Update()
    {
        audioSource.volume = musicVolume;
    }

    private void SaveDataMute()
    {
        if (PlayerPrefs.HasKey(volume))
        {
            if (PlayerPrefs.GetFloat(volume) > 0.0f)
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
            slider.value = PlayerPrefs.GetFloat(volume, musicVolume);
        }
    }

    public void MuteAudio(bool toggle)
    {
        if (toggle)
        {
            AudioListener.volume = audioSource.volume;
            PlayerPrefs.SetFloat(volume, audioSource.volume);
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetFloat(volume, 0);
        }
        PlayerPrefs.Save();
    }

    public void UpdateVolume(float volumeU)
    {
        musicVolume = volumeU;
    }
}
