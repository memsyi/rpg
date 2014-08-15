using UnityEngine;
using System.Collections;

public class MonsterCreature : Creature
{
	public MonsterCreature (string cname, int level, float str, float con, float dex, float agi, float inte, float wis, float luck) :
		base(cname,level,str,con,dex,agi,inte,wis,luck)
	{
		
	}
}
