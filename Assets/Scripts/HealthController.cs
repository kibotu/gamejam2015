using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float Health;
	public float MaxHealth = 100;
	public Animation dieAnimation;
    private Color startColor;

	public void start(){

		Health = MaxHealth;
        startColor = GetComponent<SpriteRenderer> ().color;

	}

	public void ApplyDamage(float damage)
	{
		if (Health > 0) {
			Health -=damage;
            GetComponent<SpriteRenderer> ().color = Color.red;
            Debug.Log (gameObject.name + " red");
            StopCoroutine ("Colorize");
            StartCoroutine ("Colorize");

			if(Health <= 0){
				StartCoroutine(Die());


			}
		}
	}
    public IEnumerator Colorize() {
        yield return new WaitForSeconds (0.3f);
        Debug.Log (gameObject.name + " reset color");
        GetComponent<SpriteRenderer> ().color = startColor;
    }


	IEnumerator Die(){
		GetComponent<Animator>().Play("Die");
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}


}