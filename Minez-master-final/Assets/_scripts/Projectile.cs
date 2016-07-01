using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    
    public ScoreManager scoreManager;

    private float _speed = 35;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("sManager").GetComponent<ScoreManager>();
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            scoreManager.Score += 150;
            KillSelf();
            //Destroy(other.gameObject);


        }
       
    }
    void KillSelf()
    {
        
        Destroy(gameObject);
    }
}
