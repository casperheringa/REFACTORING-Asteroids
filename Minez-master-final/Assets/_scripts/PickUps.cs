using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    [HideInInspector]

    public Vector3 rotation;
    public float rotationSpeed;
    //public PlayerShooting ps;

	void Start(){
			//ps = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerShooting> ();
    }
	void Update () {

       
        transform.Rotate (new Vector3 (60, 0, 60) * Time.deltaTime);
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (this.gameObject);
			//ps.poweredUp = true;
		}

	}


}