using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;

	float speed = 50f;
	float maxDistance = 10f;
	float range;
	Vector2 offset;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{
		range = Vector2.Distance (transform.position, player.transform.position);

		if (range > maxDistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
		}

		Rotating ();
	}

	void Rotating ()
	{
		offset = player.transform.position - transform.position;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.AngleAxis (angle, new Vector3(0, 0, 1));
	}
}
