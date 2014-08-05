using UnityEngine;
using System.Collections;

public class PlayerControls: MonoBehaviour
{
		public float speed;
		private Vector3 targetPosition;
		private Transform _transform;
		public Transform target;
		// Use this for initialization
		void Start ()
		{
				_transform = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				// Check if the left mouse button was clicked
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
						// Create a Ray object at the mouse position
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						// Create a RayCastHit property to get the output from RayCast
						RaycastHit hit;
						// Get the RayCast hit from the mouse position to the direction it is pointing at
						if (Physics.Raycast (ray, out hit, 100.0f)) {
								if (hit.collider.tag == "Targetable") {
										target = hit.collider.transform;
										target.renderer.material.color = Color.red;
								} else {
										// Create a plane at the current position
										Plane plane = new Plane (Vector3.up, _transform.position);
										// Get the RayCast hit from the mouse position to the direction it is pointing at
										float hitdist;
										// Check if the ray was at a valid position
										if (plane.Raycast (ray, out hitdist)) {
												// Get the point where the ray hit
												targetPosition = ray.GetPoint (hitdist);
												// Face the transform at the hit location
												transform.rotation = Quaternion.LookRotation (targetPosition - _transform.position);
												;
										}
								} 
						}
				}
				if (Input.GetKeyDown (KeyCode.Mouse1)) { 
						if (target) {
								target.renderer.material.color = Color.white;
								target = null;
						}
				}
				if (Vector3.Distance (_transform.position, targetPosition) > 0.1f) {
						_transform.position = Vector3.MoveTowards (_transform.position, targetPosition, Time.deltaTime * speed);
				}
		}
}
