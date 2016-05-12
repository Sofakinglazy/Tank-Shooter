using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager instance = null;

	public Text timeText;
	public Text levelText;
	public Text scoreText;
	public Image healthIcon;
	public Slider healthSlider;
	public Button nextWaveBtn;
	public Text deadText;
	public Button againBtn;

	GameObject player;
	string time;
	int score;
	int level;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		timeText.enabled = true;
		levelText.enabled = true;
		scoreText.enabled = true; 
		healthIcon.enabled = true;
		nextWaveBtn.gameObject.SetActive (false);
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
		//DontDestroyOnLoad (gameObject);
	}

	void OnDestroy(){
		instance = null;
	}

	void Update (){
		timeText.text = time;
		scoreText.text = "Score: " + score;
		levelText.text = "Level: " + level;

		healthSlider.value = player.GetComponent<PlayerHealth> ().currentHealth;
	}

	public void ShowTime(float time){
		this.time = FormatTime (time);
	}

	public void ShowLevel(int level){
		this.level = level;
	}

	public void ShowNextWaveBtn(){
		Time.timeScale = 0;
		nextWaveBtn.gameObject.SetActive (true);
	}

	public void AddScore (int scorePoint){
		score += scorePoint;
	}

	string FormatTime(float time){
		string min = Mathf.Floor (time / 60).ToString("00");
		string sec = Mathf.RoundToInt (time % 60).ToString("00");
		return min + " : " + sec;
	}

	public void DeathUI(){
		deadText.gameObject.SetActive(true);
		againBtn.gameObject.SetActive (true);
		healthSlider.gameObject.SetActive(false);
		nextWaveBtn.gameObject.SetActive (false);
		timeText.enabled = false;
		levelText.enabled = false;
		scoreText.enabled = false;
		healthIcon.enabled = false;
	}
		
}
