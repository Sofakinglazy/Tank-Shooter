using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static int[] LEVELS_PARA = { 
					// Enemy, AmmoPack, HealthPack, ExposiveBarrel, Survive Time//
		/* Level1 */	2,		1, 			1,			3,				60,
		/* Level2 */	4,		1,			1,			3,				80,
		/* Level3 */	6,		2,			2,			3,				100,
		/* Level4 */	8,		2,			2,			3,				150,
		/* Level5 */	10,		2,			2,			3,				170,
		/* Level6 */	12,		3,			3,			3,				190,
		/* Level7 */	14,		3,			3,			3,				200,
		/* Level8 */	16,		4,			3,			3,				200,
		/* Level9 */	18,		4,			3,			3,				250,
		/* Level0 */	20,		4,			4,			3,				300
	};
}
