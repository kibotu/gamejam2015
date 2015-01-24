using System;
using UnityEngine;

namespace watdowedonow
{
	public class MoveToTarget : MonoBehaviour
	{
		public Vector3 StartPosition;
		public Transform Target;
		public float Velocity;
		private float _startTime;
		public Vector3 dir;
		public float MinDistance = 0.001f;
		public Easing.Type Ease = Easing.Type.LinearEaseIn;
		public Action<MoveToTarget> OnComplete;
		public bool rotateTowards = true;

		public void Start()
		{
			StartPosition = transform.position;
		}
		
		public void Update()
		{
			if (Target == null) 
			{
				Destroy(gameObject);
				return;
			}
			
			// transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.delta * Velocity); // not good enough interpolation
			_startTime += Time.deltaTime;
			// http://whydoidoit.com/2012/04/06/unity-curved-path-following-with-easing/
			transform.position = new Vector3
			{
				x = Mathf.Lerp(StartPosition.x, Target.position.x, Ease.Ease(_startTime * Velocity)),
				y = Mathf.Lerp(StartPosition.y, Target.position.y, Ease.Ease(_startTime * Velocity)),
				z = Mathf.Lerp(StartPosition.z, Target.position.z, Ease.Ease(_startTime * Velocity))
			}; 
			
			// rotate along forward axe of camera towards target
			dir = transform.position.Direction(Target.transform.position);
			
			// allign to camera (billboard)
			// transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
			// however we want the gameobject pointing its up vector towards the target position
			if (rotateTowards)
			{
				transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * dir);
			}
			
			// if reached, apply damage and destroy rocket
			if (Vector3.Distance(transform.position, Target.transform.position) < MinDistance) 
			{
				if(OnComplete != null)
				{
					OnComplete(this);
				}	
			}
		}
	}
}
