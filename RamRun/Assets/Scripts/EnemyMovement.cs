using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        transform.Rotate(90.0f, 0, 0);
        //}
        //// Otherwise...
        //else
        //{
        //    // ... disable the nav mesh agent.
        //    nav.enabled = false;
        //}
    }
}
