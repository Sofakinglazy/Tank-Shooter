using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static int score;

	public Text scoreText;
	public Slider healthSlider;

	GameObject player;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update (){
		scoreText.text = "Score: " + score;

		healthSlider.value = player.GetComponent<PlayerHealth> ().currentHealth;
	}
}
