using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    [SerializeField] private GameObject bombPrefab;

    [SerializeField] private KeyCode inputKey = KeyCode.Space;
    [SerializeField] private float bombFuseTime = 3f;
    public int bombAmount = 1;

    public int bombRemaining;

    [SerializeField] private ExplosionManager explosionManager;

    private void OnEnable()
    {
        bombRemaining = bombAmount;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (bombRemaining > 0 && Input.GetKeyDown(inputKey))
            {
                StartCoroutine(PlaceBomb());
            }
        }
    }

    private IEnumerator PlaceBomb()
    {
        //Redondeo la pos a un entero
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        //Instancio bomba y resto 1
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombRemaining--;

        //Espero el tiempo
        yield return new WaitForSeconds(bombFuseTime);

        //Redondeo la pos de la bomba para pasarsela a la explosion
        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        //Instancio la explosion
        Explosion explosion = Instantiate(explosionManager.explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);               //Arranca la primera animacion
        explosion.DestroyAfter(explosionManager.explosionDuration);      //Despues de ciertos segundos se destruye la explosion

        //Indico hacia donde explota
        explosionManager.Explode(position, Vector2.up, explosionManager.explosionRadius);
        explosionManager.Explode(position, Vector2.down, explosionManager.explosionRadius);
        explosionManager.Explode(position, Vector2.right, explosionManager.explosionRadius);
        explosionManager.Explode(position, Vector2.left, explosionManager.explosionRadius);

        //Destruyo la bomba y sumo 1 mas
        Destroy(bomb);
        bombRemaining++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Muevo la bomba una vez que salgo
        if (collision.gameObject.CompareTag("Bomb"))
        {
            collision.isTrigger = false;
        }
    }
}
