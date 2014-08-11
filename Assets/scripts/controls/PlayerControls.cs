using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
[RequireComponent(typeof(Movement))]
public class PlayerControls: MonoBehaviour
{
	private Transform _transform;
	private Actor _actor;
	private Movement _movement;
	
	// Use this for initialization
	void Start ()
	{
		_transform = transform;
		_actor = GetComponent<Actor> ();
		_movement = GetComponent<Movement> ();
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
					_actor.target = hit.collider.transform;
					_actor.target.renderer.material.color = Color.red;
					if (hit.collider.tag == "Enemy") {
						_actor.inCombat = true;
						_movement.destination = hit.collider.transform.position;
						_transform.rotation = Quaternion.LookRotation (hit.collider.transform.position - _transform.position);
					} else {
						_actor.inCombat = false;
					}
				} else {
					// Create a plane at the current position
					Plane plane = new Plane (Vector3.up, _transform.position);
					// Get the RayCast hit from the mouse position to the direction it is pointing at
					float hitdist;
					// Check if the ray was at a valid position
					if (plane.Raycast (ray, out hitdist)) {
						// Get the point where the ray hit
						_movement.destination = ray.GetPoint (hitdist);
						// Face the transform at the hit location
						_transform.rotation = Quaternion.LookRotation (_movement.destination - _transform.position);
						if (_actor.target) {
							_actor.ResetTarget ();
						}
					}
				} 
			}
		}
		if (Input.GetMouseButtonDown (1)) { 
			//if (_actor.target) {
			//_actor.ResetTarget ();
			//}
		}
		
//		if (_actor.target && _actor.inCombat) {
//			if (Vector3.Distance (_transform.position, _actor.target.collider.ClosestPointOnBounds (_transform.position)) < 1.5f) {
//				_actor.PerformAction (_actor.target);
//				_actor.inCombat = false;
//				_movement.Stop ();
//			}
//		}
	}
}
