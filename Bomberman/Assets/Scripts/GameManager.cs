using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    [SerializeField] private GameObject spawneableDoor;
    private bool spawnDoor = false;

    private int rnd = 0;

    [SerializeField] private Gameover gameover;

    private void Update()
    {
        PlayerDie();
    }

    private void OnEnable()
    {
        ParedDestruible.onBlockSpawn += Spawn;
        ParedDestruible.onBlockDespawn += Despawn;
    }

    private void OnDisable()
    {
        ParedDestruible.onBlockSpawn -= Spawn;
        ParedDestruible.onBlockDespawn -= Despawn;
    }

    private void Spawn()
    {
        count++;
    }

    private void Despawn(Vector3 pos)
    {
        count--;

        rnd = Random.Range(0, 10);

        if (!spawnDoor)
        {
            if (rnd >= 8)
            {
                spawnDoor = true;
                Instantiate(spawneableDoor, pos, Quaternion.identity);
            }

            if (count <= 0)
            {
                spawnDoor = true;
                Instantiate(spawneableDoor, pos, Quaternion.identity);
            }
        }
    }

    private void PlayerDie()
    {
        if (EnemiMovement.playerDie)
        {
            Time.timeScale = 0f;
            gameover.Setup();
        }
    }
}
