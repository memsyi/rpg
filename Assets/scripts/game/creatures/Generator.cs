using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
	public GameObject[] list;
	public float respawnTime;
	private float timeRemaining;
	
	public State _state;
	
	private Transform _transform;
	
	public enum State
	{
		Idle,
		Initialize,
		Action
	}
	
	void Awake ()
	{
		_state = State.Initialize;
		_transform = transform;
	}
	// Use this for initialization
	IEnumerator Start ()
	{
		while (true) {
			switch (_state) {
			case State.Initialize:
				Initialize ();
				break;
			case State.Idle:
				Idle ();
				break;
			case State.Action:
				Action ();
				break;
			}
			yield return 0;
		}
	}
	private void Initialize ()
	{
		_state = Generator.State.Idle;
	}
	private void Idle ()
	{
		if (timeRemaining <= 0) {
			_state = Generator.State.Action;
		} else if (transform.childCount <= 0) {
			timeRemaining -= Time.deltaTime;
		}
	}
	private void Action ()
	{
		GameObject go = Instantiate (list [Random.Range (0, list.Length)], _transform.position, _transform.rotation) as GameObject;
		go.transform.parent = _transform;
		timeRemaining = respawnTime;
		_state = Generator.State.Idle;
		
	}
}
