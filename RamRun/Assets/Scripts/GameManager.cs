using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int score;
	public Text theText;
    public Text gameOverText;
    public Text restartText;
	public Image blackBG;
	public AudioSource bgMusic;
	public AudioSource enemySound;
	public AudioSource cliffSound;

    public float acceleration;
	public float speed;
	public float destroyPoint;
	//public float spawnProbability;
	public float spawnTime;
	public Vector3 spawnPosition;
	public GameObject obstacle;
    public MeshRenderer rndr_floor;
    public MeshRenderer rndr_background1;
    public MeshRenderer rndr_background2;
    public MeshRenderer rndr_background3;


    private static bool enemyKilled = false;
    private float timer;
    private float speedTimer;
    private List<GameObject> obstacles;
    private bool gameOver;
    private bool restart;

    void Awake () {
		obstacles = new List<GameObject> ();
		timer = 0f;
        speedTimer = 0f;
		theText.text = "Score: " + score;
        gameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        restart = false;
    }

	void Update () {
        theText.text = "Score: " + score;

		if (enemyKilled) {
			enemySound.Play ();
			enemyKilled = false;
		}

        if (restart)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
				score = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
        else if (gameOver) {
            restartText.text = "Tap to Restart";
			Color temp = blackBG.color;
			temp.a=1f;
			blackBG.color = temp;
			bgMusic.enabled = false;
            restart = true;
        } else {
            timer += Time.deltaTime;
            if (Time.timeSinceLevelLoad - speedTimer > 10)
            {
                speed += acceleration;
                speedTimer = Time.timeSinceLevelLoad;
            }

            rndr_floor.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 20.0f, 0);
            rndr_background1.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 100f, 0);
            rndr_background2.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 100f, 0);
            rndr_background3.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 100f, 0);

            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                if (obstacles[i].transform.position.x < destroyPoint)
                {
                    Destroy(obstacles[i]);
                    obstacles.RemoveAt(i);
                }
                else obstacles[i].transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
            }

            if (timer > spawnTime)
            {
                spawnObstacle();
                timer -= spawnTime;
            }
        }

		if (GameObject.FindGameObjectWithTag ("Player").transform.position.x < destroyPoint - 0.5f) {
			if (!gameOver) {
				cliffSound.Play ();
				GameOver ();
			}
		}
    }    	

	void spawnObstacle() {
        GameObject ob = Instantiate (obstacle, spawnPosition, Quaternion.AngleAxis(90.0f, new Vector3(1,0,0))) as GameObject;
        float rn = Random.Range(2f, 8f);
        ob.transform.localScale = new Vector3(2.25f, rn, 1); // Random.Range(;
        Vector3 pos = ob.transform.position;
        if (rn > 4.5) pos.z += rn/4.5f;
        ob.transform.position = pos;
        obstacles.Add(ob);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

	public static void EnemySound() {
		enemyKilled = true;
	}
}
