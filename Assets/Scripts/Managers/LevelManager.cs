using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class LevelManager : MonoBehaviour {

	public static int[] PARAS = { 
					// Enemy, Pickups, ExposiveBarrel, Survive Time//
		/* Level1 */    2,        1,          3,           20,
		/* Level2 */    6,        1,          3,           40,
		/* Level3 */    9,        2,          3,           60,
		/* Level4 */    12,       2,          3,           80,
		/* Level5 */    16,       2,          3,           100,
		/* Level6 */    20,       3,          3,           120,
		/* Level7 */    30,       3,          3,           140,
		/* Level8 */    35,       3,          3,           160,
		/* Level9 */    40,       3,          3,           180,
		/* Level0 */    60,       4,          3,           200
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
		for (int i = 0; i < 10; i++) {
			sb.Append (PARAS[4 * i] + ", " + PARAS[4 * i + 1] + ", " + PARAS[4 * i + 2] + ", " + PARAS[4 * i + 3]);
			sb.AppendLine ();
		}
//		sb.Append (PARAS[0] + ", " + PARAS[1] + ", " + PARAS[2] + ", " + PARAS[3]);
//		sb.AppendLine ();
//		sb.Append (PARAS[4] + ", " + PARAS[5] + ", " + PARAS[6] + ", " + PARAS[7]);
//		sb.AppendLine ();
//		sb.Append (PARAS[8] + ", " + PARAS[9] + ", " + PARAS[10] + ", " + PARAS[11]);
		return sb.ToString ();
	}
}
