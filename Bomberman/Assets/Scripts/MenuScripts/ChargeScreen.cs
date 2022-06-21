using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChargeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private Slider slider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Load());
        }
    }

    private IEnumerator Load()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("PlayScene");

        if (loadOperation.isDone == false)
        {
            float progressF = Mathf.Clamp01(loadOperation.progress / .09f);
            slider.value = progressF;
            textProgress.text = "" + progressF * 100 + "%";

            yield return null;
        }
    }
}
