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
    public MeshRenderer rndr;

    private float timer;
	private List<GameObject> obstacles;

	void Awake () {
		obstacles = new List<GameObject> ();
		timer = 0f;
	}

	void Update () {
		timer += Time.deltaTime;

        rndr.material.mainTextureOffset += new Vector2(Time.deltaTime * 0.1f, 0);

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
