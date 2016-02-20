using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    //public GameObject explosion;
    //public GameObject playerExplosion;
    private GameManager gameManager;
    private EnemyManager enemyManager;

    void Start()
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        if (mainCameraObject != null)
        {
            gameManager = mainCameraObject.GetComponent<GameManager>();
            enemyManager = mainCameraObject.GetComponent<EnemyManager>();
        }

        if (gameManager == null)
        {
            Debug.Log("Cannot find 'GameManager' script");
        }

        if (enemyManager == null)
        {
            Debug.Log("Cannot find 'EnemyManager' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skull")
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameManager.GameOver();
            enemyManager.GameOver();
        }
    }
}
