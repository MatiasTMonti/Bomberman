using UnityEngine;
using UnityEngine.UI;

public class UInteraction : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;

    public static System.Action<float> OnVolumeChange;
    public static System.Func<float> OnVolumeSet;

    private void Start()
    {
        float value = (float)OnVolumeSet?.Invoke();

        slider.value = value;
    }

    public void ChangeSlider(float volume)
    {
        slider.value = volume;
        OnVolumeChange?.Invoke(volume);
    }
}
