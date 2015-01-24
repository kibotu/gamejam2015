using UnityEngine;

namespace watdowedonow
{
	public class Origin : MonoBehaviour
	{
		public Vector3 origin;
		public float BackToOriginVelocity = 1f;
		public Easing.Type EasingToOrigin = Easing.Type.SinusoidalEaseIn;

		public void Awake()
		{
			origin = transform.position;
		}
	
		public void SnapBackToOrigin(System.Action onFinished = null)
		{
			var mtt = gameObject.AddComponent<MoveToTarget>();
			mtt.rotateTowards = false;
			mtt.Velocity = BackToOriginVelocity;
			mtt.Ease = EasingToOrigin;

			Transform t = new GameObject("Origin").transform;
			t.position = origin;
			mtt.Target = t;
			mtt.OnComplete += result => {
				Destroy(result);
				Destroy(t.gameObject);

				if (onFinished != null)
				{
					onFinished();
				}
			};
		}
	}
}