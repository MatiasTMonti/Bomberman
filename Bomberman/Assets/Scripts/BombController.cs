using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    [SerializeField] private GameObject bombPrefab;

    [SerializeField] private KeyCode inputKey = KeyCode.Space;
    [SerializeField] private float bombFuseTime = 3f;
    [SerializeField] private int bombAmount = 1;

    private int bombRemaining;

    [Header("Explosion")]
    [SerializeField] private Explosion explosionPrefab;
    [SerializeField] private LayerMask explosionLayerMask;
    [SerializeField] private float explosionDuration = 1f;
    [SerializeField] private int explosionRadius = 1;

    [Header("Destructible")]
    [SerializeField] private GameObject destructible;
    [SerializeField] private Destructible destructiblePrefab;

    private void OnEnable()
    {
        bombRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
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
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);   //Arranca la primera animacion
        explosion.DestroyAfter(explosionDuration);      //Despues de ciertos segundos se destruye la explosion

        //Indico hacia donde explota
        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);

        //Destruyo la bomba y sumo 1 mas
        Destroy(bomb);
        bombRemaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        //Me aseguro que pueda explotar hacia los costados
        if (length <= 0)
            return;

        //Aseguro el lado y la posicion en cual explota
        position += direction;

        //Reviso que la layermask sea la indicada y pueda explotar en caso de que no retorna
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            //ClearDestructible(position);
            return;
        }

        //Instancio la explosion en la ultima posicion de la bomba
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);     //Si ya paso la primera animacion entonces va la segunda
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Muevo la bomba una vez que salgo
        if (collision.gameObject.CompareTag("Bomb"))
        {
            collision.isTrigger = false;
        }
    }

    //private void ClearDestructible(Vector2 pos)
    //{
    //    if (destructible != null)
    //    {
    //        Instantiate(destructiblePrefab, pos, Quaternion.identity);
    //    }
    //}
}
