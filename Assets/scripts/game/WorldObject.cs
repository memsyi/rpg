using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour
{
	public Team team = Team.Neutral;

	public enum Team
	{
		Neutral,
		Friendly,
		Item,
		Enemy
	}
}
