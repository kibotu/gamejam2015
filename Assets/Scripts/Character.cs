using UnityEngine;

public class Character : MonoBehaviour
{
    public InputController input;
    public float speed;
    public int id;

	public GameObject CharacterSprite;

	private bool facingRight = true;

    public AttackController attackCtrl;

    public Animator animator;
    void Start()
    {
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
        animator.SetInteger("AnimState",1);
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
	void NorthEast(){
        animator.SetInteger("AnimState",1);
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
	void East()
	{
        animator.SetInteger("AnimState",1);
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
	void SouthEast(){
        animator.SetInteger("AnimState",1);
		if(!facingRight)
			Flip();
		transform.Translate(speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0); 
	}
    void South()
    {
        animator.SetInteger("AnimState",1);
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
	void SouthWest(){
        animator.SetInteger("AnimState",1);
		if(facingRight)
			Flip();
		transform.Translate(-speed * Time.deltaTime / DiagonalSpeed, -speed * Time.deltaTime / DiagonalSpeed, 0);
	}
    void West()
    {
        animator.SetInteger("AnimState",1);
		if(!facingRight)
			Flip();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
	void NorthWest(){
        animator.SetInteger("AnimState",1);
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
        enemy.Defend(attackCtrl);
    }

    void Defend(AttackController attackCtrl)
    {
        GetComponent<HealthController>().ApplyDamage(attackCtrl.Damage);
    }
}
