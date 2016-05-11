using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager instance = null;

	public static int score;

	public Text scoreText;
	public Slider healthSlider;
	public Text deadText;

	GameObject player;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		scoreText.enabled = true; 
		healthSlider.enabled = true;
		deadText.enabled = false;
	}

	void Awake (){
		if (instance == null) {
			instance = this; 
		} else if (instance != this) {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
	}

	void Update (){
		scoreText.text = "Score: " + score;

		healthSlider.value = player.GetComponent<PlayerHealth> ().currentHealth;
	}

//	public static void deadUI(){
//		deadText.enabled = true;
//
//		scoreText.enabled = false; 
//		healthSlider.enabled = false;
//	}
}
