using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //transform refers to the parent opject
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;


    [SerializeField] float speed = 1f;
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            
            // if waypoint index is greater than the total index, go back to the first waypoint
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //Allows platform to move between the waypoints
        //First Parameter is the current location of the waypoint/platform
        //Second parameter is the waypoint that the platform would like to move towards (index 0 means the first way point)
        //Third Parameter is the speed of how fast the platform moves
        //Time.deltaTime is used as the speed will update every frame per second (meaning the platform moves based off the FPS)
        //Time.deltaTime is the speed from the last fram to the current frame
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
