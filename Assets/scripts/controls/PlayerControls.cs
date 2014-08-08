using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class PlayerControls: MonoBehaviour
{
		public float speed;
		public Transform target;

		private Vector3 _destination;
		private Transform _transform;
		private bool _attacking;

		private Actor actor;
	
		// Use this for initialization
		void Start ()
		{
				_transform = transform;
				actor = _transform.GetComponent<Actor> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				// Check if the left mouse button was clicked
				if (Input.GetMouseButton (0)) {
						// Create a Ray object at the mouse position
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						// Create a RayCastHit property to get the output from RayCast
						RaycastHit hit;
						// Get the RayCast hit from the mouse position to the direction it is pointing at
						if (Physics.Raycast (ray, out hit, 100.0f)) {
								if (hit.collider.tag == "Targetable" || hit.collider.tag == "Enemy") {
										target = hit.collider.transform;
										target.renderer.material.color = Color.red;
										if (hit.collider.tag == "Enemy") {
												_attacking = true;
												_destination = hit.collider.transform.position;
										} else {
												_attacking = false;
										}
								} else {
										// Create a plane at the current position
										Plane plane = new Plane (Vector3.up, _transform.position);
										// Get the RayCast hit from the mouse position to the direction it is pointing at
										float hitdist;
										// Check if the ray was at a valid position
										if (plane.Raycast (ray, out hitdist)) {
												// Get the point where the ray hit
												_destination = ray.GetPoint (hitdist);
												// Face the transform at the hit location
												_transform.rotation = Quaternion.LookRotation (_destination - _transform.position);
												if (target) {
														ResetTarget ();
												}
										}
								} 
						}
				}
				if (Input.GetMouseButtonDown (1)) { 
						if (target) {
								ResetTarget ();
						}
				}
				if (_transform.position != _destination) {
						if (Vector3.Distance (_transform.position, _destination) > 0.1f && !_attacking) {
								MoveToPosition (_destination);
						} else if (target && _attacking && Vector3.Distance (_transform.position, target.collider.ClosestPointOnBounds (_transform.position)) > 1.5f) {
								MoveToPosition (_destination);
						} else {
								Stop ();
						}
				}
				if (target && _attacking) {
						if (Vector3.Distance (_transform.position, target.collider.ClosestPointOnBounds (_transform.position)) < 1.5f) {
								actor.PerformAction (target);
								_attacking = false;
								Stop ();
						}
				}
		}

		void Stop ()
		{
				_destination = _transform.position;
		}
		void ResetTarget ()
		{
				target.renderer.material.color = Color.white;
				target = null;
				_attacking = false;
		}
		void MoveToPosition (Vector3 targetPosition)
		{
				_transform.position = Vector3.MoveTowards (_transform.position, targetPosition, Time.deltaTime * speed);
		}
}
