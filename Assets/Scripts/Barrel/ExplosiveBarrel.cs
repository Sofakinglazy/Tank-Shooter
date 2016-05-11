using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour {

	public int startHealth = 60;
	[HideInInspector]
	public int currentHealth;

	public int damage;
	public int range;

	public GameObject exploseEffect;

	public LayerMask mask;
	Ray2D exploseRay;
	RaycastHit2D[] exploseHit;

	void Start (){
		currentHealth = startHealth;
	}

	void Update(){
		if (currentHealth <= 0) {
			Explose ();
			DamageWithinDist ();
		}
	}

	void Explose () {

		GameObject exploseObject = Instantiate (exploseEffect, transform.position, Quaternion.identity) as GameObject;
		exploseObject.GetComponent<ParticleSystem> ().Play();

		Destroy (gameObject);
		Destroy (exploseObject, 2);
	}

	void DamageWithinDist(){
		exploseHit = Physics2D.CircleCastAll (transform.position, range, new Vector2(1f, 1f), range, mask.value);
		if (exploseHit.Length > 0) {
			for (int i = 0; i < exploseHit.Length; i++) {
				GameObject hit = exploseHit [i].collider.gameObject;
				if (hit.CompareTag ("Enemy")) {
					hit.GetComponent<EnemyHealth> ().Death ();
				}
				if (hit.CompareTag ("Player")) {
					hit.GetComponent<PlayerHealth> ().TakeDamage (damage);
				}
			}
		}
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
	}

}
