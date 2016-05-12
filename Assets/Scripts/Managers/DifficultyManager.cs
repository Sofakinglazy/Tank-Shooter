using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

	public static DifficultyManager instance = null;

	public bool isNextLevel;
	public float adjust = 0.9f; 
	public int rank; 

	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this) {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
	}

	void OnDestroy(){
		instance = null;
	}

	void Update (){
		if (isNextLevel) {
			UpdateLevelParas ();
		}
	}

	void UpdateLevelParas (){
		// if finish task easily, then the time is longer, more enemies, less pickups, 
		// if the task is too difficult, then more pickups, time is shorter, timeBetweenPickupSpawn drops, 
		// timeBetweenEnemySpawn increases

	}
}
