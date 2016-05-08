using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

	public int healthPoint = 40;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			other.SendMessage ("AddHealthPoint", healthPoint);
			Destroy (gameObject);
		}
	}
}
