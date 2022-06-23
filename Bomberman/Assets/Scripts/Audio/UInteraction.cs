using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class UInteraction : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public static Action<float> OnVolumeChange;
    //public static Func<float> OnVolumeSet;

    public UnityEvent<float> onApplicationQuit;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    public void ChangeSlider(float volume)
    {
        slider.value = volume;
        OnVolumeChange?.Invoke(volume);
    }

    private void OnApplicationQuit()
    {
        onApplicationQuit?.Invoke(slider.value);
    }
}
