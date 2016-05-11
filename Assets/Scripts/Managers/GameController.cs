using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public Transform[] enemySpawn;
	public Transform[] barrelSpawn;

	public GameObject[] enemies;
	public GameObject ammoPack;
	public GameObject healthPack;
	public GameObject barrel;

	public Boundary boundary;

	public float timeBetweenEnemySpawn;
	int enemyCount;

	public float timeBetweenPickupSpawn;
	int pickupCount;

	int level;
	float[] timer;

	void Start ()
	{
		timer = new float[3];
		SpawnBarrels ();
	}

	void Update ()
	{
		timer[1] += Time.deltaTime;
		if (timer[1] > timeBetweenEnemySpawn && enemyCount < LevelManager.LEVELS_PARA [5 * level]) {
			SpawnEnemies ();
		}

		timer[2] += Time.deltaTime;
		if (timer[2] > timeBetweenPickupSpawn && pickupCount < LevelManager.LEVELS_PARA [5 * level + 2]) {
			SpawnPickup ();
		}

		UIManager.instance.ShowLevel (level + 1);

		timer [0] += Time.deltaTime;
		if (timer [0] > 30f && level < 10) {
			level++;
			enemyCount = 0;
			pickupCount = 0;
			timer [0] = 0;
			Debug.Log ("Level up");
		}
	}

	void SpawnEnemies ()
	{
		int indexSpawn = GetRandomNum (0f, enemySpawn.Length - 1);
		int indexEnemy = GetRandomNum (0f, enemies.Length - 1);

		Instantiate (enemies [indexEnemy], enemySpawn [indexSpawn].position, Quaternion.identity);

		timer[1] = 0f;
		enemyCount++;
	}

	void SpawnBarrels ()
	{ 
		for (int i = 0; i < barrelSpawn.Length; i++) {
			Instantiate (barrel, barrelSpawn [i].position, Quaternion.identity);
		}
	}

	void SpawnPickup ()
	{
		Vector3 randPos = new Vector3 (GetRandomNum (boundary.xMin, boundary.xMax), GetRandomNum (boundary.yMin, boundary.yMax), 0f);
		Instantiate (healthPack, randPos, Quaternion.identity);

		timer[2] = 0f;
		pickupCount++;
	}

	int GetRandomNum (float min, float max)
	{
		float random = Random.Range (min, max);
		return Mathf.RoundToInt (random);
	}
}
