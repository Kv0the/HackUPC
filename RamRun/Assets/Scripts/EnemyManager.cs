using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;

    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // If the player has no health left...
        //if (playerHealth.currentHealth <= 0f)
        //{
        //    // ... exit the function.
        //    return;
        //)

        Instantiate(enemy, new Vector3(-10, Random.Range(-4, 4), 0), new Quaternion());
    }
}
