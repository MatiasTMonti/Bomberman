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

    [Header("Destructible")]
    public Destructible destructiblePrefab;

    [SerializeField] private BombManager bombManager;

    private Shake shake;

    private void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

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
        Explosion explosion = Instantiate(bombManager.explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);   //Arranca la primera animacion
        explosion.DestroyAfter(bombManager.explosionDuration);      //Despues de ciertos segundos se destruye la explosion

        //Indico hacia donde explota
        bombManager.Explode(position, Vector2.up, bombManager.explosionRadius);
        bombManager.Explode(position, Vector2.down, bombManager.explosionRadius);
        bombManager.Explode(position, Vector2.right, bombManager.explosionRadius);
        bombManager.Explode(position, Vector2.left, bombManager.explosionRadius);

        //Destruyo la bomba y sumo 1 mas
        Destroy(bomb);
        //shake.CamShake();
        bombRemaining++;
    }
}
