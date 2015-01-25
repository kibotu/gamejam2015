﻿using UnityEngine;

public class Character : MonoBehaviour
{
    public InputController input;
    public float speed;
    public int id;

	public GameObject CharacterSprite;

	private bool facingRight = true;

    public AttackController attackCtrl;

    public Animator animator;
    private PlayerStats playerStats;
   

    public float normalSpeed;
    void Start()
    {
        normalSpeed = speed;
        playerStats = GetComponent<PlayerStats>();
        if (input != null){
            input.OnKeydown += OnKeydown;
            input.Attack += Attack;
        }
    }

    public static float DiagonalSpeed = Mathf.Sqrt(2);

    public void OnKeydown(Direction dir)
    {
        switch (dir)
        {
            case Direction.NORTH: North(); break;
			case Direction.NORTH_EAST: NorthEast();	break;
            case Direction.EAST: West(); break;
			case Direction.SOUTH_EAST: SouthEast();	break;
            case Direction.SOUTH: South(); break;
			case Direction.SOUTH_WEST: SouthWest(); break; 
			case Direction.WEST: East(); break;
			case Direction.NORTH_WEST: NorthWest();break;
        }
    }

    void North()
    {
        animator.Play("char_run");
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
	void NorthEast(){
        animator.Play("char_run");
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
	void East()
	{
        animator.Play("char_run");
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
	void SouthEast(){
        animator.Play("char_run");
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
    void South()
    {
        animator.Play("char_run");
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
	void SouthWest(){
        animator.Play("char_run");
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0);
	}
    void West()
    {
        animator.Play("char_run");
		if(!facingRight)
			Flip();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
	void NorthWest(){
        animator.Play("char_run");
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0);
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = CharacterSprite.transform.localScale;
		scale.x *= -1;
		CharacterSprite.transform.localScale = scale;
	}

    void Attack()
    {
        animator.SetInteger("AnimState",2);
        if(attackCtrl != null) attackCtrl.Attack();
    }

    public void AttackEnemy(Character enemy)
    {
        if (enemy.Defend(attackCtrl))
            playerStats.kills +=1;
    }

    bool Defend(AttackController attackCtrl)
    {
       return GetComponent<HealthController>().ApplyDamage(attackCtrl.Damage);
    }
}
