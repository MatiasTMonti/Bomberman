using UnityEngine;

public class Destructible : MonoBehaviour
{
    private float destructionTime = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float itemSpawnChance = 0.2f;
    [SerializeField] private GameObject[] spawneableItems;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }

    private void OnDestroy()
    {
        if (spawneableItems.Length > 0 && Random.value < itemSpawnChance)
        {
            int randomIndex = Random.Range(0, spawneableItems.Length);
            Instantiate(spawneableItems[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
