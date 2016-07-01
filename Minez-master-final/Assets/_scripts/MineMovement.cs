using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineMovement : MonoBehaviour
{
    public Transform[] wayPoints;
    private int waypointIndex;


    private NavMeshAgent nav;
    public float speed = 5f;


    void Start()
    {
        //Y = 3.5f;   
    }

    void Awake()
    {

        nav = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        //  transform.LookAt((wayPoints[waypointIndex].position));
        move();

    }

    void move()
    {
        nav.speed = speed;
       
            if (nav.remainingDistance < 0.5)
            {
                waypointIndex = Random.Range(0, wayPoints.Length);
            }
            nav.SetDestination(wayPoints[waypointIndex].position);
        
    }
}
