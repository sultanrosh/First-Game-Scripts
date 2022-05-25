using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int enemyWaypointIndex = 0;


    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[enemyWaypointIndex].transform.position) < 0.1f)
        {
            enemyWaypointIndex++;
            
            if(enemyWaypointIndex >= waypoints.Length)
            {
                enemyWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[enemyWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
