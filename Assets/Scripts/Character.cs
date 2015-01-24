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
            case global::Direction.NORTH: Up(); break;
            case global::Direction.NORTH_EAST: transform.Translate(speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0); break;
            case global::Direction.EAST: Right(); break;
            case global::Direction.SOUTH_EAST: transform.Translate(speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0); break;
            case global::Direction.SOUTH: Down(); break;
            case global::Direction.SOUTH_WEST: transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0); break;
            case global::Direction.WEST: Left(); break;
            case global::Direction.NORTH_WEST: transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0); break;
        }
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
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
