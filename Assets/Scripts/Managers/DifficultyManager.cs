using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

	public static DifficultyManager instance = null;

	public bool isNextLevel;
	float adjust = 1f; 

	int healthLeft;

	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this) {
			Destroy (gameObject);
			return;
		}

//		DontDestroyOnLoad (gameObject);
	}

	void OnDestroy(){
		instance = null;
	}

	void Update(){
	}

	public void UpdateLevelParas (float timeLeft, int enemyKilled, int level){
		// if finish task easily, then the time is longer, more enemies, less pickups, 
		// if the task is too difficult, then more pickups, time is shorter, timeBetweenPickupSpawn drops, 
		// timeBetweenEnemySpawn increases

		int rank = CalcuPlayerRank (timeLeft, enemyKilled, level);
		MathModel (rank);

		for (int i = 0; i < 4; i++){
			LevelManager.PARAS [4 * i] = Mathf.RoundToInt(LevelManager.PARAS [4 * i] * adjust);
			LevelManager.PARAS [4 * i + 1] = Mathf.RoundToInt(LevelManager.PARAS [4 * i + 1] / adjust);
			LevelManager.PARAS [4 * i + 2] = Mathf.RoundToInt(LevelManager.PARAS [4 * i + 2] / adjust);
			LevelManager.PARAS [4 * i + 3] = Mathf.RoundToInt(LevelManager.PARAS [4 * i + 3] * adjust);
		}
			
		LevelManager lm = new LevelManager ();
		Debug.Log (lm);
	}

	int CalcuPlayerRank(float timeLeft, int enemyKilled, int level){
		int rank = 4;

		if (timeLeft != 0) {
			float timePercentage = timeLeft / LevelManager.TIME(level);
			if (timePercentage >= 0.6f)
				rank = 4;
			else if (timePercentage >= 0.4f)
				rank = 3;
			else if (timePercentage >= 0.3f)
				rank = 2;
			else if (timePercentage >= 0.2f)
				rank = 1;
			else
				rank = 0;
		}

		if (enemyKilled != 0) {
			float enemyPercentage = (float) enemyKilled / LevelManager.ENERMY(level);
			if (enemyPercentage >= 0.8f)
				rank = 4;
			else if (enemyPercentage >= 0.6f)
				rank = 3;
			else if (enemyPercentage >= 0.5f)
				rank = 2;
			else if (enemyPercentage >= 0.3f)
				rank = 1;
			else
				rank = 0;
		}

		Debug.Log ("Rank: " + rank);
		return rank;
	}

	void MathModel(int rank){
		float x =  (float) (4 - rank) / 5f;
		Debug.Log ("x: " + x);
		if (x >= 0f)
			adjust = (float)(1.2f - x * x * x);
		else
			adjust = 1.2f;
		Debug.Log ("Adjust: " + adjust);
	}
}
