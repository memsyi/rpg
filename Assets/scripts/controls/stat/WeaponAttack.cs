using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Actor))]
public class WeaponAttack : Action
{
	public float cooldown;
	public float timer;

	private float _damageLow;
	private float _damageHigh;
	private Creature _creature;
	// Use this for initialization
	void Start ()
	{
		_creature = GetComponent<Actor> ().creature;
		_damageLow = _creature.Damagelow;
		_damageHigh = _creature.Damagehigh;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer >= 0.0f) {
			timer -= Time.deltaTime;
		}
	}

	public override void Perform (Transform target)
	{
		if (timer <= 0) {
			target.GetComponent<Health> ().UpdateHealth (-Random.Range (_damageLow, _damageHigh), 0);
			GetComponentInChildren<Animator> ().ResetTrigger ("Swing");
			GetComponentInChildren<Animator> ().SetTrigger ("Swing");
			timer = cooldown;
		}
	}
}
