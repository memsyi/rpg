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
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		public void UpdateHealth (float health, float wound)
		{
				_creature.currentHealth += health;
		}
}
