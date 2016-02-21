using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    private EnemyManager enemyManager;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        if (mainCameraObject != null)
        {
            enemyManager = mainCameraObject.GetComponent<EnemyManager>();
        }

        if (enemyManager == null)
        {
            Debug.Log("Cannot find 'EnemyManager' script");
        }
    }


    void Update()
    {
        if (nav.enabled)
        {
            if (enemyManager.isGameOver())
            {
                nav.enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                nav.SetDestination(player.position);
            }
            transform.Rotate(90.0f, 0, 0);
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
