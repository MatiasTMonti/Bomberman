using UnityEngine;

public class BombManager : MonoBehaviour
{

    [Header("Explosion")]
    public Explosion explosionPrefab;
    [SerializeField] private LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    [SerializeField] private BombController bombController;

    public void Explode(Vector2 position, Vector2 direction, int length)
    {
        //Me aseguro que no explote mas del limite
        if (length <= 0)
            return;

        //Aseguro el lado y la posicion en cual explota
        position += direction;

        //Reviso que la layermask sea la indicada y pueda explotar, en caso de que no retorna
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestructible(position);
            return;
        }

        //Instancio la explosion en la ultima posicion de la bomba
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);     //Si ya paso la primera animacion entonces va la segunda
        explosion.SetDirection(direction);      //Sin esto la animacion aparece en cualquier lado
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1); //Sin esto se rompe la explosion, cuando upgradeo
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Muevo la bomba una vez que salgo
        if (collision.gameObject.CompareTag("Bomb"))
        {
            collision.isTrigger = false;
        }
    }

    //Instancio el destructor de la bomba
    private void ClearDestructible(Vector2 pos)
    {
        Instantiate(bombController.destructiblePrefab, pos, Quaternion.identity);
    }

    //Para no romper el upgrade
    public void AddBomb()
    {
        bombController.bombAmount++;
        bombController.bombRemaining++;
    }
}
