using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] popUp;

    private int popUpIndex = 0;

    private float timer = 0f;

    private const float maxTimbetweenPopup = 4f;

    private void Update()
    {
        timer += Time.deltaTime;

        //if (popUp[popUpIndex] == popUp[0] && timer >= 1)
        //{
        //    popUp[0].SetActive(true);
        //    popUpIndex++;
        //}
        //else if (popUp[popUpIndex] == popUp[1] && timer >= 4)
        //{
        //    popUp[0].SetActive(false);
        //    popUp[1].SetActive(true);
        //    popUpIndex++;
        //}
        //else if (popUp[popUpIndex] == popUp[2] && timer >= 8)
        //{
        //    popUp[1].SetActive(false);
        //    popUp[2].SetActive(true);
        //    popUpIndex++;
        //}
        //else if (popUp[popUpIndex] == popUp[3] && timer >= 12)
        //{
        //    popUp[2].SetActive(false);
        //    popUp[3].SetActive(true);

        //    if (timer > 16)
        //    {
        //        popUp[3].SetActive(false);
        //    }
        //}
        
        for (int i = 0; i < popUp.Length - 1; i++)
        {        
            if (popUpIndex < popUp.Length && popUp[popUpIndex] == popUp[i])
            {
                popUp[i].SetActive(true);
            }

            if (timer >= maxTimbetweenPopup)
            {
                popUpIndex++;
            }

            if (popUpIndex < popUp.Length && popUpIndex > 0 && timer >= maxTimbetweenPopup)
            {
                popUp[popUpIndex - 1].SetActive(false);
                timer = 0;
            }
        }
    }
}
