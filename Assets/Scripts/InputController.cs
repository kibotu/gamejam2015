using UnityEngine;
using System.Collections;
using System;

public class InputController : MonoBehaviour
{
    public event Action<Direction> OnKeydown;

    void Update()
    {
        Keyboard();
        XBoxController();
    }

    public void Keyboard()
    {
//        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
    
//        if(Input.GetMouseButtonDown(1))
//        if(Input.GetMouseButtonDown(2))

       
        #region catch inputs
        // NORTH_EAST
        if (KeyboardUp() && KeyboardRight())
        {
            OnKeydown(Direction.NORTH_EAST);
        }
        // NORTH_WEST
        else if (KeyboardUp() && KeyboardLeft())
        {
            OnKeydown(Direction.NORTH_WEST);
        }
        // SOUTH_EAST
        else if (KeyboardDown() && KeyboardRight())
        {
            OnKeydown(Direction.SOUTH_EAST);
        }
        // SOUTH_WEST
        else if (KeyboardDown() && KeyboardLeft())
        {
            OnKeydown(Direction.SOUTH_WEST);
        }
        // NORTH
        else if (KeyboardUp())
        {
            OnKeydown(Direction.NORTH);
        }
        // EAST
        else if (KeyboardRight())
        {
            OnKeydown(Direction.EAST);
        }
        // WEST
        else if (KeyboardLeft())
        {
            OnKeydown(Direction.WEST);
        }
        // SOUTH
        else if (KeyboardDown())
        {
            OnKeydown(Direction.SOUTH);
        }
        // MIDDLE
        else {
            // idle
        }
        #endregion
    }

    #region player inputs
    public bool KeyboardUp()
    {
        return Input.GetKey("up") || Input.GetKey(KeyCode.W);
    }
    public bool KeyboardLeft()
    {
        return Input.GetKey("left") || Input.GetKey(KeyCode.A);
    }
    public bool KeyboardDown()
    {
        return Input.GetKey("down") || Input.GetKey(KeyCode.S);
    }
    public bool KeyboardRight()
    {
        return Input.GetKey("right") || Input.GetKey(KeyCode.D);
    }
    #endregion

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