using UnityEngine;
using System;

public class ParedDestruible : MonoBehaviour, IDestruible
{
    public static Action onBlockSpawn;
    public static Action<Vector3> onBlockDespawn;

    private void Start()
    {
        onBlockSpawn?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destruible"))
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
        onBlockDespawn?.Invoke(transform.position);
    }
}
