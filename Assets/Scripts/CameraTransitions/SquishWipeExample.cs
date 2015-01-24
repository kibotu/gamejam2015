using UnityEngine;
using System.Collections;

public class SquishWipeExample : MonoBehaviour 
{
    public Camera camera1;
    public Camera camera2;
    public float wipeTime = 2.0f;
    public AnimationCurve curve;
	private bool inProgress = false;
	private bool swap = false;

	void Update ()
	{
		if (Input.GetKeyDown("up")) 
		{
			DoWipe(ScreenWipe.TransitionType.Up);
		}
		else if (Input.GetKeyDown("down")) 
		{
			DoWipe(ScreenWipe.TransitionType.Down);
		}
		else if (Input.GetKeyDown("left")) 
		{
			DoWipe(ScreenWipe.TransitionType.Left);
		}
		else if (Input.GetKeyDown("right")) 
		{
			DoWipe(ScreenWipe.TransitionType.Right);
		}
	}

    public void StartSquishLeft() {
        DoWipe(ScreenWipe.TransitionType.Left);
    }

    public void StartSquishRight() {
        DoWipe(ScreenWipe.TransitionType.Right);
    }

    public void StartSquishUp() {
        DoWipe(ScreenWipe.TransitionType.Up);
    }

    public void StartSquishDown() {
        DoWipe(ScreenWipe.TransitionType.Down);
    }

	void DoWipe ( ScreenWipe.TransitionType transitionType  )
	{
		if (inProgress) return;
		inProgress = true;
		
		swap = !swap;
		StartCoroutine( ScreenWipe.use.SquishWipe (swap? camera1 : camera2, swap? camera2 : camera1, wipeTime, transitionType, curve) );
		
		inProgress = false;
	}
}