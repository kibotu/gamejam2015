using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public float damage;

	void OnTriggerEnter2D(Collider2D other){
		print (other.name);
		if(other.CompareTag("Player")){
			other.GetComponent<HealthController>().ApplyDamage(damage);
		}
	}
}
