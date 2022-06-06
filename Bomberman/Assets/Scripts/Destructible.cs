using UnityEngine;

public class Destructible : MonoBehaviour
{
    private float destructionTime = 1f;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }
}
