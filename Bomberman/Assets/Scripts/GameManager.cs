using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int countBlock;
    public int countEnemies;
    public static bool enemiesLive = false;
    public static bool playerWin = false;

    [SerializeField] private GameObject spawneableDoor;
    [SerializeField] private Gameover gameoverLose;
    [SerializeField] private Gameover gameoverWin;

    private bool spawnDoor = false;
    private int rnd = 0;

    private const int maxRandomNumber = 10;

    private const int maxChanceSpawnRandomDoor = 8;

    [SerializeField] private PlayerLogic playerLogic;   

    private void Start()
    {
        playerWin = false;
        EnemiesInput.playerDie = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        PlayerDie();
        PlayerWin();

        IsEnemiesAlive();
    }

    private void OnEnable()
    {
        ParedDestruible.onBlockSpawn += SpawnBlocks;
        ParedDestruible.onBlockDespawn += DespawnBlocks;

        EnemiesInput.onEnemieSpawn += SpawnEnemies;
        EnemiesInput.onEnemieDespawn += DespawnEnemies;
    }

    private void OnDisable()
    {
        ParedDestruible.onBlockSpawn -= SpawnBlocks;
        ParedDestruible.onBlockDespawn -= DespawnBlocks;

        EnemiesInput.onEnemieSpawn -= SpawnEnemies;
        EnemiesInput.onEnemieDespawn -= DespawnEnemies;
    }

    private void SpawnBlocks()
    {
        countBlock++;
    }

    private void DespawnBlocks(Vector3 pos)
    {
        countBlock--;

        DoorChanceSpawn(pos);
    }

    private void SpawnEnemies()
    {
        countEnemies++;
    }

    private void DespawnEnemies()
    {
        countEnemies--;
    }

    private void DoorChanceSpawn(Vector3 pos)
    {
        rnd = Random.Range(0, maxRandomNumber);

        if (!spawnDoor)
        {
            if (rnd >= maxChanceSpawnRandomDoor)
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

    private void IsEnemiesAlive()
    {
        if (countEnemies <= 0)
        {
            enemiesLive = true;
        }
    }

    private void PlayerDie()
    {
        if (EnemiesInput.playerDie)
        {
            Time.timeScale = 0f;
            gameoverLose.Setup();
        }
    }

    private void PlayerWin()
    {
        if (playerWin)
        {
            Time.timeScale = 0f;
            gameoverWin.Setup();
        }
    }
}
