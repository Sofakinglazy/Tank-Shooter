using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage = 5;
	public float timeBetweenDamage = 0.5f;

	float timer;
	bool withinDistance;
	GameObject player;

	void Start (){
		withinDistance = false;
	}

	void Update (){
		timer += Time.deltaTime;
		if (withinDistance && timer >= timeBetweenDamage) {
			Attack ();
		}
	}
	void Attack (){
		player.SendMessage ("TakeDamage", damage);
		timer = 0;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			withinDistance = true;
			player = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			withinDistance = false;
		}
	}
}
