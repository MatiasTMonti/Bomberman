using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Movement player;

    private void Start()
    {
        player = GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        player.AnimationsDeath();

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);

        EnemiMovement.playerDie = true;
    }
}
