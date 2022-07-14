using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrese,
    }

    [SerializeField] ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<ExplosionManager>().AddBomb();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<ExplosionManager>().explosionRadius++;
                break;
            case ItemType.SpeedIncrese:
                player.GetComponent<PlayerInput>().speed++;
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
