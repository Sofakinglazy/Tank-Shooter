using UnityEngine;
using System.Collections;

public class EnemyHealth : PlayerHealth{

	public int scorePoints;
	ParticleSystem hitParticles;
	Animator anim;

	void Start(){
		currentHealth = startHealth;
		hitParticles = GetComponent<ParticleSystem> ();
		anim = GetComponent<Animator> ();

	}

	void Update(){
		if (this.currentHealth <= 0) {
			StartCoroutine(Death ());
		}
	}


	public override IEnumerator Death (){
		
		GetComponent<EnemyMovement> ().isDead = true;
		anim.SetTrigger ("Explose");
		float animLength = GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length;
		yield return new WaitForSeconds (animLength);
		UIManager.instance.AddScore (scorePoints);
		Destroy (gameObject);
	}

	public virtual void TakeDamage(int damage, Vector3 hitPoint){
		hitParticles.transform.position = hitPoint;

		hitParticles.Stop ();
		hitParticles.Play ();

		this.currentHealth -= damage;
	}

}
