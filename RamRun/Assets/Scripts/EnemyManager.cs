using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;
    public bool enemyWaves;

    void Start () {
        if (enemyWaves) InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // If the player has no health left...
        //if (playerHealth.currentHealth <= 0f)
        //{
        //    // ... exit the function.
        //    return;
        //)

        Instantiate(enemy, new Vector3(-8, 0, Random.Range(1, 4)), Quaternion.AngleAxis(90.0f, new Vector3(1, 0, 0)));
    }
}
