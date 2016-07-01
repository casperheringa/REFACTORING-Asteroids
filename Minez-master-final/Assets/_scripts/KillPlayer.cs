using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
		if (other.CompareTag ("playerBullet")) 
		{
			
            Destroy(this.gameObject);
		}
    }
}
