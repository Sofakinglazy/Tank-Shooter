using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager instance = null;

	public Text scoreText;
	public Image healthIcon;
	public Slider healthSlider;
	public Text deadText;
	public Button againBtn;

	GameObject player;
	static int score;

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

	public void AddScore (int scorePoint){
		score += scorePoint;
	}

	public void DeathUI(){
		deadText.gameObject.SetActive(true);
		againBtn.gameObject.SetActive (true);
		healthSlider.gameObject.SetActive(false);
		scoreText.enabled = false;
		healthIcon.enabled = false;
	}

	public void LoadLevel(){
		Debug.Log ("Load level");
	}
}
