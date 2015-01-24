using UnityEngine;
using System.Collections;
using System;

public class InputController : MonoBehaviour
{

    public event Action Player1Down;
    public event Action Player1Up;
    public event Action Player1Left;
    public event Action Player1Right;

    void Update()
    {
        Keyboard();
        XBoxController();
    }

    void Keyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Player1Up();
            Debug.Log("W Pressed.");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player1Down();
            Debug.Log("S Pressed.");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player1Left();
            Debug.Log("A Pressed.");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player1Right();
            Debug.Log("D Pressed.");
        }
    }

    // xbox 360 joystick http://wiki.unity3d.com/index.php?title=Xbox360Controller
    /// <summary>
    /// A = joystick button 0
    /// B = joystick button 1
    /// X = joystick button 2
    /// Y = joystick button 3
    /// LB = joystick button 4
    /// RB = joystick button 5
    /// Back = joystick joystick button 6
    /// Start = joystick button 7
    /// Left Analogue Press = joystick button 8
    /// Right Analogue Press = joystick button 9 
    /// </summary>
    void XBoxController()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("A Pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("B Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("X Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("Y Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Debug.Log("LB Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Debug.Log("RB Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Debug.Log("Back Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("Start Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            Debug.Log("Left Analog Pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            Debug.Log("Right Analog Pressed.");
        }
    }
}