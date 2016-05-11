using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController instance;

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
	int enemyKilled;

	void Start ()
	{
		timer = new float[3];
		SpawnBarrels ();
	}

	void Awake (){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
			return;
		}
		//DontDestroyOnLoad (gameObject);
	}

	void OnDestroy(){
		instance = null;
	}

	void Update ()
	{
		timer[1] += Time.deltaTime;
		if (timer[1] > timeBetweenEnemySpawn && enemyCount < LevelManager.ENERMY(level)) {
			SpawnEnemies ();
		}

		timer[2] += Time.deltaTime;
		if (timer[2] > timeBetweenPickupSpawn && pickupCount < LevelManager.HEALTH_PACK(level)) {
			SpawnPickup ();
		}

		UIManager.instance.ShowLevel (level + 1);

		timer [0] += Time.deltaTime;
		if ((timer [0] > LevelManager.TIME(level) || enemyKilled == LevelManager.ENERMY(level)) && level < 10) {
			level++;
			Reset ();
			DestroyRestEnemies ();
		}
		UIManager.instance.ShowTime (LevelManager.TIME(level) - timer [0]);
	}

	void DestroyRestEnemies(){
		GameObject[] rest = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < rest.Length; i++) {
			rest [i].GetComponent<EnemyHealth> ().currentHealth = 0;
		}
	}

	void Reset (){
		enemyCount = 0;
		pickupCount = 0;
		timer [0] = 0;
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

	public void Increment(){
		enemyKilled++;
	}

	public void LoadLevel(){
		Application.LoadLevel (0);
		Debug.Log ("Load level");
	}
}
