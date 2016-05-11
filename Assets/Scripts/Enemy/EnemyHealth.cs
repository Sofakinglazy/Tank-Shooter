using UnityEngine;
using System.Collections;

public class EnemyHealth : PlayerHealth{

	public int scorePoints;
	ParticleSystem hitParticles;

	void Start(){
		currentHealth = startHealth;
		hitParticles = GetComponent<ParticleSystem> ();
	}

	void Update(){
		if (this.currentHealth <= 0) {
			Death ();
		}
	}


	public override void Death (){
		Destroy (gameObject);
		UIManager.instance.AddScore (scorePoints);
		Debug.Log ("Enermy is dead!");
	}

	public virtual void TakeDamage(int damage, Vector3 hitPoint){
		hitParticles.transform.position = hitPoint;

		hitParticles.Stop ();
		hitParticles.Play ();

		this.currentHealth -= damage;
	}

}
