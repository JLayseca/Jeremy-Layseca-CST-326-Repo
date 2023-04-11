using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    //private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    void Update()
    {
        /*
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);
        */

        GetComponent<NavMeshAgent>().SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) <= 30f)
        {
            EndPath();
        }
        

        enemy.speed = enemy.startSpeed;
    }

    /*
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {

            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    */

    void EndPath ()
    {
        PlayerStats.HP--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
