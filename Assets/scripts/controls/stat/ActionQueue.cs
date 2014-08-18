using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueue : MonoBehaviour
{
	private List<string> actions;
	private int max = 1;
	// Use this for initialization
	void Start ()
	{
		actions = new List<string> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void QueueAction (string action)
	{
		if (actions.Count < max) {
			actions.Add (action);
		}
	}

	public void PerformAction (Transform target)
	{
		if (actions.Count == 0) {
			GetComponent<WeaponAttack> ().Perform (target);
		} else {
			actions.RemoveAt (0);
		}
	}
}
