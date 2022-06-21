using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public static bool playerWin = false;

    private void Start()
    {
        playerWin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerWin = true;
        }
    }
}
