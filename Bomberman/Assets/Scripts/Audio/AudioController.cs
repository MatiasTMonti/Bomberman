using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float musicVolume = 1f;
    private AudioSource audioSource;

    private void OnEnable()
    {
        UInteraction.OnVolumeChange += UpdateVolume;
    }

    private void OnDisable()
    {
        UInteraction.OnVolumeChange -= UpdateVolume;
    }

    public void UpdateVolume(float volumeU)
    {
        audioSource.volume = volumeU;
    }
}
