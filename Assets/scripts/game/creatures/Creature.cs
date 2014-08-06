using UnityEngine;
using System.Collections;

public abstract class Creature
{
		public string cname;
		public float currentHealth;
		public float currentMana;
		public float currentStamina;
		public int level = 1;

		public float strength = 1;
		public float constitution = 1;
		public float dexterity = 1;
		public float agility = 1;
		public float intelligence = 1;
		public float wisdom = 1;
		public float luck = 1;

		private float health = 1;
		private float stamina = 1;
		private float mana = 1;
		private float damagelow = 1;
		private float damagehigh = 1;
		private float critical = 1;
		private float evasion = 1;
		private float hit = 1;
		private float resist = 1;

		public Creature (string cname, int level, float strength, float constitution, float dexterity, float agility, float intelligence, float wisdom, float luck)
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
				health = (strength * 0.3f) + (constitution * 1.2f);
				mana = (intelligence * 2.2f) + (wisdom * 1.6f);
				stamina = (strength * 0.2f) + (constitution * 1.8f);
				damagelow = (strength * 0.8f) + (dexterity * 1.8f);
				damagehigh = (strength * 1.8f) + (dexterity * 0.4f);
				critical = (dexterity * 0.6f) + (agility * 0.6f) + (luck);
				evasion = (dexterity * 0.4f) + (agility * 0.9f) + (luck * 0.5f);
				hit = (dexterity * 1.6f) + (agility * 0.6f) + (luck * 0.3f);
				resist = (intelligence * 0.6f) + (wisdom * 1.9f) + (luck * 0.5f);
		}

		float Health {
				get {
						return this.health;
				}
		}

		float Stamina {
				get {
						return this.stamina;
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
