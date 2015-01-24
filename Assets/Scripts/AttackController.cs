using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {
   
    public Animator animator;
    public float Damage;
    public PolygonCollider2D collider;
    public void Attack(){
        animator.Play("Attack");
    }
    void Update(){
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            collider.enabled = true;
        
        } else {

            collider.enabled = false;

        }
    }
    

}