using UnityEngine;
using UnityEngine.UI;

public class UInteraction : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;
    public static System.Action<float> OnVolumeChange;

    private void Awake()
    {
        slider.value = 1f;
    }

    public void ChangeSlider(float volume)
    {
        slider.value = volume;
        OnVolumeChange(volume);
    }
}
