using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    public InputController input;
    public float speed;

	private bool facingRight = true;

    void Start()
    {
        input.OnKeydown += OnKeydown;
    }

    public static float DiagonalSpeed = Mathf.Sqrt(2);

    private void OnKeydown(Direction dir)
    {
        switch (dir)
        {
            case global::Direction.NORTH: North(); break;
			case global::Direction.NORTH_EAST: NorthEast();	break;
            case global::Direction.EAST: West(); break;
			case global::Direction.SOUTH_EAST: SouthEast();	break;
            case global::Direction.SOUTH: South(); break;
			case global::Direction.SOUTH_WEST: SouthWest(); break; 
			case global::Direction.WEST: East(); break;
			case global::Direction.NORTH_WEST: NorthWest();break;
        }
    }

    void North()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
	void NorthEast(){
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
	void East()
	{
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
	void SouthEast(){
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
    void South()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
	void SouthWest(){
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0);
	}
    void West()
    {
		if(!facingRight)
			Flip();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
	void NorthWest(){
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0);
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
