using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class Health : MonoBehaviour
{
	private Creature _creature;
	// Use this for initialization
	void Start ()
	{
		_creature = GetComponent<Actor> ().creature;
	}

	public void UpdateHealth (float health, float wound)
	{
		_creature.currentHealth += health;
		if (_creature.currentHealth > _creature.Health) {
			_creature.currentHealth = _creature.Health;
		}
	}
}
