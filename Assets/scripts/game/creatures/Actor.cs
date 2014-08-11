using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ActionQueue))]
public class Actor : MonoBehaviour
{

	public string cname = "";
	public int level = 1;
	
	public float strength = 1;
	public float constitution = 1;
	public float dexterity = 1;
	public float agility = 1;
	public float intelligence = 1;
	public float wisdom = 1;
	public float luck = 1;

	public Transform target;
	public bool inCombat = false;

	private Creature _creature;
	private ActionQueue _queue;
		
	// Use this for initialization
	void Awake ()
	{
		_creature = new PlayerCreature (cname, level, strength, constitution, dexterity, agility, intelligence, wisdom, luck);
		_queue = GetComponent<ActionQueue> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public Creature creature {
		get {
			return this._creature;
		}
	}

	public void PerformAction (Transform target)
	{
		_queue.PerformAction (target);
	}
	
	public void ResetTarget ()
	{
		target.renderer.material.color = Color.white;
		target = null;
		inCombat = false;
	}
}
