using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager instance = null;

	public Text levelText;
	public Text scoreText;
	public Image healthIcon;
	public Slider healthSlider;
	public Text deadText;
	public Button againBtn;

	GameObject player;
	int score;
	int level;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		levelText.enabled = true;
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
		levelText.text = "Level: " + level;

		healthSlider.value = player.GetComponent<PlayerHealth> ().currentHealth;
	}

	public void ShowLevel(int level){
		this.level = level;
	}

	public void AddScore (int scorePoint){
		score += scorePoint;
	}

	public void DeathUI(){
		deadText.gameObject.SetActive(true);
		againBtn.gameObject.SetActive (true);
		healthSlider.gameObject.SetActive(false);
		levelText.enabled = false;
		scoreText.enabled = false;
		healthIcon.enabled = false;
	}

	public void LoadLevel(){
		Debug.Log ("Load level");
	}
}
