using UnityEngine;

public class Gameover : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);    
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }
}
