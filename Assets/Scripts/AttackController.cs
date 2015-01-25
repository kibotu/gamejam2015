using UnityEngine;
using System.Collections;
using System;

public class AttackController : MonoBehaviour {
   
    public Animator animator;
    public float Damage;
    public PolygonCollider2D polygonCollider;
    public TrailRenderer trailrenderer;
    public void Attack(){

        animator.Play("char_attack");
    }
    void Update(){
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("char_attack")) {
            polygonCollider.enabled = true;
            //trailrenderer.enabled = true;
        
        } else {

            polygonCollider.enabled = false;
            //trailrenderer.enabled = false;

        }
    }
    

}