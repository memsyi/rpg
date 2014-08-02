using UnityEngine;
using System.Collections;

public abstract class Creature
{
		public string cname;

		public int level = 1;

		public float strength;
		public float constitution;
		public float dexterity;
		public float agility;
		public float intelligence;
		public float wisdom;
		public float luck;

		private float health = 1;
		private float mana = 1;
		private float damagelow = 1;
		private float damagehigh = 1;
		private float critical = 1;
		private float evasion = 1;
		private float hit = 1;
		private float resist = 1;

		public Creature ()
		{

		}

		public Creature (string cname, float strength, float constitution, float dexterity, float agility, float intelligence, float wisdom, float luck)
		{
				this.cname = cname;
				this.strength = strength;
				this.constitution = constitution;
				this.dexterity = dexterity;
				this.agility = agility;
				this.intelligence = intelligence;
				this.wisdom = wisdom;
				this.luck = luck;
		}

		public void UpdateStats ()
		{
		
		}

		float Health {
				get {
						return this.health;
				}
		}

		float Mana {
				get {
						return this.mana;
				}
		}

		float Damagelow {
				get {
						return this.damagelow;
				}
		}

		float Damagehigh {
				get {
						return this.damagehigh;
				}
		}

		float Critical {
				get {
						return this.critical;
				}
		}

		float Evasion {
				get {
						return this.evasion;
				}
		}

		float Hit {
				get {
						return this.hit;
				}
		}

		float Resist {
				get {
						return this.resist;
				}
		}
		
}
