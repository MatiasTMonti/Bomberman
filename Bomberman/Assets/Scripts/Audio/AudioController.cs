using UnityEngine;

public class AudioController : MonoBehaviour
{
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
