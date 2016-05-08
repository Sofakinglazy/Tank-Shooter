using UnityEngine;
using System.Collections;

public class AmmoPack : MonoBehaviour {
	
	public int ammoAmount = 100;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			other.GetComponentInChildren<PlayerShooting> ().AddAmmo (ammoAmount);
			Destroy (gameObject);
		}
	}
}
