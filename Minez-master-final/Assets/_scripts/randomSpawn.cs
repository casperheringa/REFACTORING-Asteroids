using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomSpawn : MonoBehaviour {

    public PickUps pickUp;
    private float i;
    public Transform[] wayPoints;
    private int waypointIndex;

    

    void Start()
    {
        i = 0;
    }
	// Update is called once per frame
	void Update ()
    {
        if (i < Time.time)
        {
            i = Time.time + 10f;
            spawn();
        }
        
    }

    void spawn ()
    {
        
            waypointIndex = Random.Range(0, wayPoints.Length);
          
            PickUps square  = Instantiate(pickUp, wayPoints[waypointIndex].position, wayPoints[waypointIndex].rotation) as PickUps;

    }
}
