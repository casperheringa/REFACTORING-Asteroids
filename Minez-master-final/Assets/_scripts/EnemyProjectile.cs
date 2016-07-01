using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    private float _speed = 1;
    public PlayerHealth ph;
    // Use this for initialization
    void Start () {
        ph = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
        Destroy(gameObject, 15f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            ph.currentHealth -= 80;
            
			Destroy (this.gameObject);

        }

    }
}
