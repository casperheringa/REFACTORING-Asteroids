using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMovement : MonoBehaviour
{
    public Transform[] wayPoints;
    private int waypointIndex;
    private Transform player;

    private NavMeshAgent nav;
    public float speed = 5f;
    private EnemyShooting es;


    void Start()
    {
        //Y = 3.5f;   
    }

    void Awake()
    {

        es = GetComponent<EnemyShooting>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        //  transform.LookAt((wayPoints[waypointIndex].position));
        move();

    }

    void move()
    {
        nav.speed = speed;
        if (es.inRange == false)
        {
            if (nav.remainingDistance < 0.5)
            {
                waypointIndex = Random.Range(0, wayPoints.Length);
            }
            nav.SetDestination(wayPoints[waypointIndex].position);
        }
        else if(es.inRange == true)
        {
            nav.SetDestination(player.position);
        }
    }
}
