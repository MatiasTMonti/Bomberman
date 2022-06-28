using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PlayerInput player;

    private void Start()
    {
        player = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion") || collision.gameObject.CompareTag("Enemies"))
        {
            DeathSequence();
        }

        if (GameManager.enemiesLive)
        {
            if (collision.gameObject.CompareTag("Door"))
            {
                WinSequence();
            }
        }
    }

    public void DeathSequence()
    {
        player.AnimationsDeath();

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);

        GameManager.playerDie = true;
    }

    public void WinSequence()
    {
        player.AnimationWin();

        Invoke(nameof(OnWinSequenceEnded), 1.25f);
    }

    private void OnWinSequenceEnded()
    {
        gameObject.SetActive(false);

        GameManager.playerWin = true;
    }
}
