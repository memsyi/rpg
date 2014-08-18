using UnityEngine;
using System.Collections;

public class PlayerActor : Actor
{

	private static PlayerActor instance = null;

	public void Awake ()
	{
		_creature = new PlayerCreature (cname, level, strength, constitution, dexterity, agility, intelligence, wisdom, luck);
		_queue = GetComponent<ActionQueue> ();
		
		instance = this;
	}
	
	public static PlayerActor Instance {
		get {
			if (!instance) {
				GameObject go = Instantiate (Resources.Load ("prefabs/player")) as GameObject;
				go.name = "Player";
			}
			return  instance;
		}
	}
}
