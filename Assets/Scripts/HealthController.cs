using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
    public float spawnTime = 1;
    public float dieTime = 3;
	
	public float Health;
	public float MaxHealth = 10;
	public Animation dieAnimation;
    private Color startColor;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collider2D playerCollider;
    public BoxCollider2D levelBounds;
    private Vector2 min;
    private Vector2 max;
	public void start(){
        min = levelBounds.bounds.min;
        max = levelBounds.bounds.max;

		Health = MaxHealth;
        startColor = spriteRenderer.color;

	}

	public bool ApplyDamage(float damage)
	{
		if (Health > 0) {
			Health -=damage;

            /* BleedingStuff
            spriteRenderer.color = Color.red;
            Debug.Log (gameObject.name + " red");
            StopCoroutine ("Colorize");
            StartCoroutine ("Colorize");
            */

			if(Health <= 0){
				StartCoroutine(Die());
                return true;

			}
            return false;
		}
        return true;
	}
    public IEnumerator Colorize() {
        yield return new WaitForSeconds (0.3f);
        Debug.Log (gameObject.name + " reset color");
        spriteRenderer.color = startColor;
    }


	IEnumerator Die(){
		animator.Play("char_die");
        GetComponent<Character>().move = false;
        playerCollider.enabled = false;
		yield return new WaitForSeconds(dieTime);
		//Destroy(gameObject);
        StartCoroutine(Spawn());


	}

    IEnumerator Spawn(){
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(spawnTime);
        transform.position = new Vector2 (Random.Range(min.x, max.x),Random.Range(min.y, max.y));
        Health = 100;
        spriteRenderer.enabled = true;
        animator.Play("char_idle");
        playerCollider.enabled = true;
        GetComponent<Character>().move = true;


    }


}