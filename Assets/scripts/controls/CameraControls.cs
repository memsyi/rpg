using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
		public Transform target;
		public float distance = 10.0f;
		public float xSpeed = 250.0f;
		public float ySpeed = 120.0f;

		public float minZoom = 3;
		public float maxZoom = 17;

		public float yMinLimit = -20;
		public float yMaxLimit = 80;

		private Transform _transform;
		private float _x = 0.0f;
		private float _y = 0.0f;

		void Start ()
		{
				_transform = transform;
				_transform.position = transform.rotation * new Vector3 (0.0f, 0.0f, -distance) + target.position;
		}
		void LateUpdate ()
		{
				if (Input.GetMouseButton (1)) {
						_x += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
						_y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
			
						_y = ClampAngle (_y, yMinLimit, yMaxLimit);
			
						Quaternion rotation = Quaternion.Euler (_y, _x, 0);
						Vector3 position = rotation * new Vector3 (0.0f, 0.0f, -distance) + target.position;
			
						_transform.rotation = rotation;
						_transform.position = position;
				} else {
						_transform.position = transform.rotation * new Vector3 (0.0f, 0.0f, -distance) + target.position;
				}
				if (Input.GetAxis ("Mouse ScrollWheel") > 0 && distance > minZoom) {
						distance -= 0.5f;
				} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && distance < maxZoom) {
						distance += 0.5f;
				}
		}
		float ClampAngle (float angle, float min, float max)
		{
				if (angle < -360)
						angle += 360;
				if (angle > 360)
						angle -= 360;
				return Mathf.Clamp (angle, min, max);
		}
}