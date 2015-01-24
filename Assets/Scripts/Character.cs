using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	
	public InputController input;
	public float speed;
	public bool facingRight = true;
	
	void Start()
	{
		input.Keyboard1Up += Up;
		input.Keyboard1Down += Down;
		input.Keyboard1Left += Left;
		input.Keyboard1Right += Right;
	}
	
	void Up()
	{
		transform.Translate(0, speed * Time.deltaTime, 0);
	}
	
	void Down()
	{
		transform.Translate(0, -speed * Time.deltaTime, 0);
	}
	
	void Left()
	{
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
	
	void Right()
	{
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime, 0, 0);
	}
	
	void Update()
	{
		
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
