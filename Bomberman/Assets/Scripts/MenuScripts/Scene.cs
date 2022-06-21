using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] private GameObject chargeScene;

    public void ChargeScreen()
    {
        chargeScene.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        CollisionPlayer.playerWin = false;
        EnemiMovement.playerDie = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
