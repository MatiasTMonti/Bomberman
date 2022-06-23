using UnityEngine;

public class SaveLoadAudio : MonoBehaviour
{
    private string volumeData = "volume";

    //private void OnEnable()
    //{
    //    UInteraction.OnVolumeChange += Save;
    //    UInteraction.OnVolumeSet += Load;
    //}

    //private void OnDisable()
    //{
    //    UInteraction.OnVolumeChange -= Save;
    //    UInteraction.OnVolumeSet -= Load;
    //}



    //private void Save(float volumeMusic)
    //{
    //    if (PlayerPrefs.HasKey(volumeData))
    //    {
    //        PlayerPrefs.SetFloat(volumeData, volumeMusic);
    //    }
    //}

    public void GetGameVolume(float volume)
    {
        if (PlayerPrefs.HasKey(volumeData))
        {
            PlayerPrefs.SetFloat(volumeData, volume);
        }
    }

    //private float Load()
    //{
    //    float volumeMusic = 1f;

    //    if (PlayerPrefs.HasKey(volumeData))
    //    {
    //        if (PlayerPrefs.GetFloat(volumeData) > 0.0f)
    //        {
    //            //active toggle
    //        }
    //        else
    //        {
    //            //deactive toggle
    //        }
    //        volumeMusic = PlayerPrefs.GetFloat(volumeData);
    //    }

    //    return volumeMusic;
    //}
}
