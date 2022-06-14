using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    [SerializeField] private GameObject spawneableDoor;
    private bool spawnDoor = false;

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

        if (!spawnDoor)
        {
            spawnDoor = true;
            Instantiate(spawneableDoor, pos, Quaternion.identity);
        }
    }
}
