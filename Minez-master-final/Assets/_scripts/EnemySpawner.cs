using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform spawner;
    public int time;
    public int repeatRate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", time, repeatRate);
	}
	
	// Update is called once per frame
	void Spawn () {
        Instantiate(enemy, spawner.position, spawner.rotation);
	}
}
