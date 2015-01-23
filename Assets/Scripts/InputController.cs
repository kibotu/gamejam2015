using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	void Start () {
	
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
	void Update () {
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Debug.Log("A Pressed.");
        }
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            Debug.Log("B Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Debug.Log("X Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            Debug.Log("Y Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("LB Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("RB Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button6))
        {
            Debug.Log("Back Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button7))
        {
            Debug.Log("Start Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button8))
        {
            Debug.Log("Left Analog Pressed.");
        }

        if (Input.GetKey(KeyCode.Joystick1Button9))
        {
            Debug.Log("Right Analog Pressed.");
        }
	}
}