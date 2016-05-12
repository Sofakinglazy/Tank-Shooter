using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class LevelManager : MonoBehaviour {

	public static int[] PARAS = { 
					// Enemy, Pickups, ExposiveBarrel, Survive Time//
		/* Level1 */    2,        1,          3,           20,
		/* Level2 */    4,        1,          3,           40,
		/* Level3 */    6,        2,          3,           60,
		/* Level4 */    8,        2,          3,           80,
		/* Level5 */    10,       2,          3,           100,
		/* Level6 */    12,       3,          3,           120,
		/* Level7 */    14,       3,          3,           140,
		/* Level8 */    16,       3,          3,           160,
		/* Level9 */    18,       3,          3,           180,
		/* Level0 */    20,       4,          3,           200
	};

	public static int ENERMY(int level){
		return PARAS [4 * level];
	}

	public static int PICKUPS(int level){
		return PARAS [4 * level + 1];
	}

	public static int BARREL(int level){
		return PARAS [4 * level + 2];
	}

	public static int TIME(int level){
		return PARAS [4 * level + 3];
	}

	public override string ToString ()
	{
		StringBuilder sb = new StringBuilder ();
		sb.Append (PARAS[0] + ", " + PARAS[1] + ", " + PARAS[2] + ", " + PARAS[3]);
		sb.AppendLine ();
		sb.Append (PARAS[4] + ", " + PARAS[5] + ", " + PARAS[6] + ", " + PARAS[7]);
		sb.AppendLine ();
		sb.Append (PARAS[8] + ", " + PARAS[9] + ", " + PARAS[10] + ", " + PARAS[11]);
		return sb.ToString ();
	}
}
