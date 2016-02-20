using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public float acceleration;
	public float speed;
	//public float spawnProbability;
	public float spawnTime;
	public Vector3 spawnPosition;


	private float timer;
	private List<GameObject> obstacles;

	void Awake () {
		obstacles = new List<GameObject> ();
		timer = 0f;
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime) {
			obstacles.Add(Instantiate(SmallObstacle,spawnPosition,Quaternion.identity);
		}
	}
}
