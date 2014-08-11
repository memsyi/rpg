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
		if (_transform.position != destination) {
			if (Vector3.Distance (_transform.position, destination) > 0.1f && !_actor.inCombat) {
				MoveToPosition (destination);
			} else if (_actor.target && _actor.inCombat && Vector3.Distance (_transform.position, _actor.target.collider.ClosestPointOnBounds (_transform.position)) > 1.5f) {
				MoveToPosition (destination);
			} else {
				Stop ();
			}
		}
		
		if (_actor.target && _actor.inCombat) {
			if (Vector3.Distance (_transform.position, _actor.target.collider.ClosestPointOnBounds (_transform.position)) < 1.5f) {
				_actor.PerformAction ();
				_actor.inCombat = false;
				Stop ();
			}
		}
	}

	public void MoveToPosition (Vector3 targetPosition)
	{
		_transform.position = Vector3.MoveTowards (_transform.position, targetPosition, Time.deltaTime * speed);
	}
	
	public void Stop ()
	{
		destination = _transform.position;
	}
}
