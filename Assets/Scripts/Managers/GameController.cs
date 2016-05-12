using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	public Transform[] enemySpawn;
	public Transform[] barrelSpawn;

	public GameObject[] enemies;
	public GameObject[] pickups;
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
		if (timer[2] > timeBetweenPickupSpawn && pickupCount < LevelManager.PICKUPS(level)) {
			SpawnPickup ();
		}

		UIManager.instance.ShowLevel (level + 1);

		timer [0] += Time.deltaTime;
		if ((timer [0] > LevelManager.TIME(level) || enemyKilled == LevelManager.ENERMY(level)) && level < 10) {
			UpdateLevelParas ();
			level++;
			Reset ();
			DestroyRestEnemies ();
		}
		UIManager.instance.ShowTime (LevelManager.TIME(level) - timer [0]);

	}

	void UpdateLevelParas ()
	{
		if (timer [0] < LevelManager.TIME (level)) {
			DifficultyManager.instance.UpdateLevelParas (LevelManager.TIME (level) - timer [0], 0, level);
		}
		else {
			DifficultyManager.instance.UpdateLevelParas (0, enemyKilled, level);
		}
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
		enemyKilled = 0;
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
		for (int i = 0; i < LevelManager.BARREL(level); i++) {
			Instantiate (barrel, barrelSpawn [i].position, Quaternion.identity);
		}
	}

	void SpawnPickup ()
	{
		Vector3 randPos = new Vector3 (GetRandomNum (boundary.xMin, boundary.xMax), GetRandomNum (boundary.yMin, boundary.yMax), 0f);
		int pickupIdex = GetRandomNum (0f, pickups.Length - 1);
		Instantiate (pickups[pickupIdex], randPos, Quaternion.identity);

		timer[2] = 0f;
		pickupCount++;
	}

	int GetRandomNum (float min, float max)
	{
		float random = Random.Range (min, max);
		return Mathf.RoundToInt (random);
	}

	public void IncrementDeathEnemy(){
		enemyKilled++;
	}

	public void LoadLevel(){
		SceneManager.LoadScene (0);
	}

	public void Pause (){
		Time.timeScale = 0;
	}

	public void Resume(){
		Time.timeScale = 1;
	}
}
