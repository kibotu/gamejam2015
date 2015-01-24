using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float Health;
	public float MaxHealth = 100;
	public Animation dieAnimation;


	public void start(){

		Health = MaxHealth;

	}

	public void ApplyDamage(float damage)
	{
		if (Health > 0) {
			Health -=damage;

			if(Health <= 0){
				StartCoroutine(Die());


			}
		}
	}



	IEnumerator Die(){
		GetComponent<Animator>().Play("Die");
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}


}