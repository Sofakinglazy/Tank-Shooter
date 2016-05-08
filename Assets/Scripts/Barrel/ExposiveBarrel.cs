using UnityEngine;
using System.Collections;

public class ExposiveBarrel : MonoBehaviour {

	public int startHealth = 60;
	[HideInInspector]
	public int currentHealth;
	public GameObject exploseEffect;

	void Start (){
		currentHealth = startHealth;
	}

	void Update(){
		if (currentHealth <= 0) {
			Explose ();
		}
	}

	void Explose () {

		GameObject exploseObject = Instantiate (exploseEffect, transform.position, Quaternion.identity) as GameObject;
		exploseObject.GetComponent<ParticleSystem> ().Play();

		Destroy (gameObject);
		Destroy (exploseObject, 2);
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
	}

}
