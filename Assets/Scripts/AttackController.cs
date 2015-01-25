using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {
   
    public Animator animator;
    public float Damage;
    public PolygonCollider2D collider;
    public TrailRenderer trailrenderer;
    public void Attack(){
        print("char_attack");
        animator.Play("char_attack");
    }
    void Update(){
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("char_attack")) {
            collider.enabled = true;
            trailrenderer.enabled = true;
        
        } else {

            collider.enabled = false;
            trailrenderer.enabled = false;

        }
    }
    

}