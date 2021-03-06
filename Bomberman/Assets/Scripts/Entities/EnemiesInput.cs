using UnityEngine;
using System;

public class EnemiesInput : MonoBehaviour, IDestruible
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;

    private int rnd = 0;
    private float timer = 0;

    [SerializeField] private LayerMask layer;

    public static Action onEnemieSpawn;
    public static Action onEnemieDespawn;

    void Start()
    {
        movePoint.parent = null;

        onEnemieSpawn?.Invoke();
    }

    void Update()
    {
        timer += Time.deltaTime;
        rnd = UnityEngine.Random.Range(0, 4);

        EnemiesMovement();
    }

    private void EnemiesMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (timer > 0.2f)
            {
                switch (rnd)
                {
                    case 0:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, layer))
                        {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                        }
                        break;
                    case 1:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, layer))
                        {
                            movePoint.position += new Vector3(-1f, 0f, 0f);
                        }
                        break;
                    case 2:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, layer))
                        {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                        }
                        break;
                    case 3:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, layer))
                        {
                            movePoint.position += new Vector3(0f, -1f, 0f);
                        }
                        break;
                    default:
                        break;
                }

                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
        onEnemieDespawn?.Invoke();
    }
}
