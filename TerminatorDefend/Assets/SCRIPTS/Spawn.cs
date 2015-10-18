using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    // The enemy that should be spawned
    public GameObject enemyPrefab;

    // Spawn Delay in seconds
    public float interval = 3;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnNext", interval, interval);
    }

    void SpawnNext()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
