using UnityEngine;

public class SaveLoadAudio : MonoBehaviour
{
    private string volume = "volume";

    void Start()
    {
        UInteraction.OnVolumeChange += Save;
    }

    private void OnDestroy()
    {
        UInteraction.OnVolumeChange -= Save;
    }

    private void Save(float volumeMusic)
    {
        if (PlayerPrefs.HasKey(volume))
        {
            PlayerPrefs.SetFloat(volume, volumeMusic);
        }
    }

    private bool Load(out float volumeMusic)
    {
        volumeMusic = 1f;

        if (PlayerPrefs.HasKey(volume))
        {
            if (PlayerPrefs.GetFloat(volume) > 0.0f)
            {
                //active toggle
            }
            else
            {
                //deactive toggle
            }
            volumeMusic = PlayerPrefs.GetFloat(volume);
            return true;
        }

        return false;
    }

    //int vol;
    //if(load(out vol)
    //{
    //        Debug.log("volumen");
    //}
}
