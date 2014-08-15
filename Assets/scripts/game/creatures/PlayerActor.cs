using UnityEngine;
using System.Collections;

public class PlayerActor : Actor
{
	void Awake ()
	{
		_creature = new PlayerCreature (cname, level, strength, constitution, dexterity, agility, intelligence, wisdom, luck);
		_queue = GetComponent<ActionQueue> ();
	}
}
