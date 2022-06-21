using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float musicVolume = 1f;
    private AudioSource audioSource;

    public void UpdateVolume(float volumeU)
    {
        audioSource.volume = volumeU;
    }
}
