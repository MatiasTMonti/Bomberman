using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChargeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private Slider slider;

    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return null;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("PlayScene");

        loadOperation.allowSceneActivation = false;

        while (!loadOperation.isDone)
        {
            float progressF = Mathf.Clamp01(loadOperation.progress / .09f);

            slider.value = progressF;

            textProgress.text = "" + progressF * 100 + "%";

            if (loadOperation.progress >= 0.9f)
            {
                textProgress.text = "Press space bar to continue";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    loadOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
