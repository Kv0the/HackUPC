using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public float acceleration;
	public float speed;
	public float destroyPoint;
	//public float spawnProbability;
	public float spawnTime;
	public Vector3 spawnPosition;
	public GameObject obstacle;

	private float timer;
	private List<GameObject> obstacles;

	void Awake () {
		obstacles = new List<GameObject> ();
		timer = 0f;
	}

	void Update () {
		timer += Time.deltaTime;


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
		GameObject ob = Instantiate (obstacle, spawnPosition, Quaternion.identity) as GameObject;
		ob.transform.localScale = new Vector3(0.15f,Random.Range (0.2f, 0.45f),1); // Random.Range(;
		obstacles.Add(ob);
	}
}
