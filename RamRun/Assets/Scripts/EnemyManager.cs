using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;
    public bool enemyWaves;
    private bool gameOver;

    void Start () {
        gameOver = false;
        if (enemyWaves) InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (!gameOver) Instantiate(enemy, new Vector3(-8, 0, Random.Range(10, 30)), Quaternion.AngleAxis(90.0f, new Vector3(1, 0, 0)));
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
