using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int score;
	public Text theText;

	public float acceleration;
	public float speed;
	public float destroyPoint;
	//public float spawnProbability;
	public float spawnTime;
	public Vector3 spawnPosition;
	public GameObject obstacle;
    public MeshRenderer rndr_floor;
    public MeshRenderer rndr_background;

    private float timer;
	private List<GameObject> obstacles;

	void Awake () {
		obstacles = new List<GameObject> ();
		timer = 0f;
		theText.text = "Score: " + score;
	}

	void Update () {
		theText.text = "score: " + score;
		timer += Time.deltaTime;
        if (Time.time % 10.0 == 0) speed += acceleration;

        rndr_floor.material.mainTextureOffset += new Vector2(Time.deltaTime * speed/20.0f, 0);
        rndr_background.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 100f, 0);

        for (int i = obstacles.Count-1; i >= 0; i--) {
			if (obstacles [i].transform.position.x < destroyPoint) {
				Destroy (obstacles [i]);
				obstacles.RemoveAt (i);
			}
			else obstacles[i].transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
		}

		if (timer > spawnTime) {
			spawnObstacle ();
			timer -= spawnTime;
		}
	}

	void spawnObstacle() {
		GameObject ob = Instantiate (obstacle, spawnPosition, Quaternion.AngleAxis(90.0f, new Vector3(1,0,0))) as GameObject;
        ob.transform.localScale = new Vector3(2.25f, Random.Range(2f, 4.5f), 1); // Random.Range(;

        obstacles.Add(ob);
	}
}
