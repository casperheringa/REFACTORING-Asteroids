using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public EnemyProjectile enemyProjectile;
    public Transform muzzle;
    public float bulletSpeed = 10;
    private float delayCounter = 0.0F;
    private float fireRate = 1F;
    private GameObject Player;
    private SphereCollider col;
    private Transform player;
    public Transform target;
    private bool shooting;

    public float eHealth = 100;


    public float range;
    public float seeRange;
    public bool inRange;


	
	void Start ()
    {
        inRange = false;

        //Destroy(gameObject, 120f);
	}
	
	
	void Awake ()
    {
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

	}

    void Update()
    {
        
        delayCounter -= Time.deltaTime;
    
        if(Vector3.Distance (transform.position, target.position) < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
       if(eHealth == 0)
        {
            Destroy(gameObject);
        }
        
        if (inRange == true && delayCounter <= Time.deltaTime)
        {
            transform.LookAt(player.position);
            Shoot();
        }
    }

    void Shoot()
    {
        
        shooting = true;
        EnemyProjectile bullet = Instantiate(enemyProjectile, muzzle.position, muzzle.rotation) as EnemyProjectile;
        bullet.SetSpeed(bulletSpeed);
        delayCounter = Time.deltaTime + fireRate;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerBullet"))
        {
            eHealth -= 10;
            Destroy(other.gameObject);
        }

    }
}
