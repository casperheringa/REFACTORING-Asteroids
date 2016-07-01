using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public bool poweredUp;
	public GameObject torpedo1;
	public GameObject torpedo2;
    public Transform muzzle;
    public float bulletSpeed;

    private float delayCounter = 0.0F;
    public float fireRate = 0.3F;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 if (Input.GetMouseButton(0) && Time.time > delayCounter)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
		if (!poweredUp) {
			GameObject Torpedo1 = Instantiate (torpedo1, muzzle.position, muzzle.rotation) as GameObject;
			delayCounter = Time.time + fireRate;
		} else if (poweredUp) {
			GameObject Torpedo2 = Instantiate (torpedo2, muzzle.position, muzzle.rotation) as GameObject;
			delayCounter = Time.time + fireRate;
		}
			

    }
}
