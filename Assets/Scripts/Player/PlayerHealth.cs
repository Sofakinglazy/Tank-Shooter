using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int startHealth = 100;

	[HideInInspector]
	public int currentHealth;

	void Start (){
		currentHealth = startHealth;
	}

	void Update (){
		if (currentHealth > startHealth) {
			currentHealth = startHealth;
		}

		if (currentHealth <= 0) {
			StartCoroutine (Death ());
		}
	}

	public virtual IEnumerator Death(){
		UIManager.instance.DeathUI ();
		yield return new WaitForSeconds (0);
	}

	public void TakeDamage (int damage){
		currentHealth -= damage;
	}

	public void AddHealthPoint(int healthPoint){
		currentHealth += healthPoint;
	}
}
