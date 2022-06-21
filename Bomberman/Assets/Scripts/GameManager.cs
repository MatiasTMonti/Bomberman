using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int countBlock;
    public int countEnemies;
    [SerializeField] private GameObject spawneableDoor;
    private bool spawnDoor = false;
    public static bool enemiesLive = false;

    private int rnd = 0;

    [SerializeField] private Gameover gameoverLose;
    [SerializeField] private Gameover gameoverWin;

    private void Update()
    {
        PlayerDie();
        PlayerWin();

        if (countEnemies <= 0)
        {
            enemiesLive = true;
        }
    }

    private void OnEnable()
    {
        ParedDestruible.onBlockSpawn += SpawnBlocks;
        ParedDestruible.onBlockDespawn += DespawnBlocks;

        EnemiMovement.onEnemieSpawn += SpawnEnemies;
        EnemiMovement.onEnemieDespawn += DespawnEnemies;
    }

    private void OnDisable()
    {
        ParedDestruible.onBlockSpawn -= SpawnBlocks;
        ParedDestruible.onBlockDespawn -= DespawnBlocks;

        EnemiMovement.onEnemieSpawn -= SpawnEnemies;
        EnemiMovement.onEnemieDespawn -= DespawnEnemies;
    }

    private void SpawnBlocks()
    {
        countBlock++;
    }

    private void DespawnBlocks(Vector3 pos)
    {
        countBlock--;

        rnd = Random.Range(0, 10);

        if (!spawnDoor)
        {
            if (rnd >= 8)
            {
                spawnDoor = true;
                Instantiate(spawneableDoor, pos, Quaternion.identity);
            }

            if (countBlock <= 0)
            {
                spawnDoor = true;
                Instantiate(spawneableDoor, pos, Quaternion.identity);
            }
        }
    }

    private void SpawnEnemies()
    {
        countEnemies++;
    }

    private void DespawnEnemies()
    {
        countEnemies--;
    }

    private void PlayerDie()
    {
        if (EnemiMovement.playerDie)
        {
            Time.timeScale = 0f;
            gameoverLose.Setup();
        }
    }

    private void PlayerWin()
    {
        if (CollisionPlayer.playerWin)
        {
            Time.timeScale = 0f;
            gameoverWin.Setup();
        }
    }
}
