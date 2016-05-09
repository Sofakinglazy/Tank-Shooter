using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static int[] LEVELS_PARA = { 
					// Enemy, AmmoPack, HealthPack, ExposiveBarrel //
		/* Level1 */	2,		1, 			1,			3,
		/* Level2 */	4,		1,			1,			3,
		/* Level3 */	6,		2,			2,			3,
		/* Level4 */	8,		2,			2,			3,
		/* Level5 */	10,		2,			2,			3,
		/* Level6 */	12,		3,			3,			3,
		/* Level7 */	14,		3,			3,			3,
		/* Level8 */	16,		4,			3,			3,
		/* Level9 */	18,		4,			3,			3,
		/* Level0 */	20,		4,			4,			3
	};
}
