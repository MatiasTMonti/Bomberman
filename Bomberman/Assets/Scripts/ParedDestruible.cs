using UnityEngine;

public class ParedDestruible : MonoBehaviour, IDestruible
{
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
    }
}
