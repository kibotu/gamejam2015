using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {
    
    public AudioSource touche;
    public AudioSource hitflesh;
    
    void OnCollisionEnter2D(Collision2D coll) {
        foreach (var col in coll.contacts) {

            if (coll.gameObject.tag.Equals ("Player")) {
                //Debug.Log ("hits " + col.collider.gameObject.name);
                var enemy = coll.transform.gameObject.GetComponent<Character>();
                var player = gameObject.transform.parent.parent.parent.gameObject.GetComponent<Character>();
                player.AttackEnemy(enemy);
            }

        }
    }
}