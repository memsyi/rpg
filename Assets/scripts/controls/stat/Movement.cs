using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class Movement : MonoBehaviour
{
	public float speed = 5.0f;
	public Vector3 destination;
	
	private Transform _transform;
	private Actor _actor;

	// Use this for initialization
	void Start ()
	{
		_transform = transform;
		_actor = GetComponent<Actor> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveToPosition ();
		
		if (_actor.target && _actor.inCombat) {
			if (Vector3.Distance (_transform.position, _actor.target.collider.ClosestPointOnBounds (_transform.position)) < 1.5f) {
				_actor.PerformAction ();
				_actor.inCombat = false;
			}
		}
	}

	void MoveToPosition ()
	{
		if (_transform.position != destination) {
			
			if ((Vector3.Distance (_transform.position, destination) > 0.1f && !_actor.inCombat && !_actor.target) || 
				(_actor.target && _actor.inCombat && Vector3.Distance (_transform.position, _actor.target.collider.ClosestPointOnBounds (_transform.position)) > 1.5f)) {
				_transform.position = Vector3.MoveTowards (_transform.position, destination, Time.deltaTime * speed);
				_transform.rotation = Quaternion.LookRotation (destination - _transform.position);
			} else {
				Stop ();
			}
		}
	}
	
	public void Stop ()
	{
		destination = _transform.position;
	}
}
