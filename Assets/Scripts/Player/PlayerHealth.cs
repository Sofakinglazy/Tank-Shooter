using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;

	[HideInInspector]
	public int currentHealth;

	void Start (){
		currentHealth = maxHealth;
	}

	void Update (){
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) {
			Death ();
		}
	}

	public virtual void Death(){
		Debug.Log ("player is dead.");
	}

	public virtual void TakeDamage (int damage){
		currentHealth -= damage;
		Debug.Log (currentHealth);
	}

	public void AddHealthPoint(int healthPoint){
		currentHealth += healthPoint;
		Debug.Log ("Health gets added!" + currentHealth);
	}
}
