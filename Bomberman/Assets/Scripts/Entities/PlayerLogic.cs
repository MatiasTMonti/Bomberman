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
    }

    public void DeathSequence()
    {
        player.AnimationsDeath();

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);

        EnemiesInput.playerDie = true;
    }
}
