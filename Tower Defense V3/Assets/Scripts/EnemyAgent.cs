using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    private Transform destination;

     void Start()
    {
        destination = Waypoints.points[0];

    }
   
    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);

        if (Vector3.Distance(transform.position, destination.position) <= .8f)
        {
            EndPath();
        }
    }

    void EndPath ()
    {
        PlayerStats.HP--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
