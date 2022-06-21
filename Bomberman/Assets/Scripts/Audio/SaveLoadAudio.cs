using UnityEngine;

public class SaveLoadAudio : MonoBehaviour
{
    private string volume = "volume";

    private void OnEnable()
    {
        UInteraction.OnVolumeChange += Save;
        //UInteraction.OnVolumeSet += Load;
    }

    private void OnDisable()
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

    private float Load(float volumeMusic)
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
        }

        return volumeMusic;
    }

    //int vol;
    //if(load(out vol)
    //{
    //        Debug.log("volumen");
    //}
}
