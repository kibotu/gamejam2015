using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    public InputController input;
    public float speed;

    void Start()
    {
        input.Player1Up += Up;
        input.Player1Down += Down;
        input.Player1Left += Left;
        input.Player1Right += Right;
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
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void Right()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void Update()
    {

    }
}
