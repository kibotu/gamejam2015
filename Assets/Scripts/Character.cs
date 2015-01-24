using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    public InputController input;
    public float speed;

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
