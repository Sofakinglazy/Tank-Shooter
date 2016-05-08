using UnityEngine;
using System.Collections;

public class EnemyHealth : PlayerHealth{

	ParticleSystem hitParticles;

	void Start(){
		this.currentHealth = maxHealth;
		hitParticles = GetComponent<ParticleSystem> ();
	}

	void Update(){
		if (this.currentHealth <= 0) {
			Death ();
		}
	}


	public override void Death (){
		Destroy (gameObject);
		Debug.Log ("Enermy is dead!");
	}

	public virtual void TakeDamage(int damage, Vector3 hitPoint){
		hitParticles.transform.position = hitPoint;

		hitParticles.Stop ();
		hitParticles.Play ();

		this.currentHealth -= damage;
	}

}
