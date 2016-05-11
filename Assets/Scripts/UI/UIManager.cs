using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager instance = null;

	public int score;

	public Text scoreText;
	public Image healthIcon;
	public Slider healthSlider;
	public Text deadText;
	public Button againBtn;

	GameObject player;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		scoreText.enabled = true; 
		healthIcon.enabled = true;
		healthSlider.gameObject.SetActive(true);
		deadText.gameObject.SetActive(false);
		againBtn.gameObject.SetActive (false);
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

	void OnDestroy(){
		instance = null;
	}

	void Update (){
		scoreText.text = "Score: " + score;

		healthSlider.value = player.GetComponent<PlayerHealth> ().currentHealth;
	}

	public int AddScore (int scorePoint){
		return score + scorePoint;
	}

	public void DeathUI(){
		deadText.gameObject.SetActive(true);
		againBtn.gameObject.SetActive (true);
		healthSlider.gameObject.SetActive(false);
		scoreText.enabled = false;
		healthIcon.enabled = false;
	}
}
