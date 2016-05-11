using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

	public float speed = 30f;

	float maxDistance = 10f;
	Transform player;
	float range;
	Vector3 offset;
	[HideInInspector]
	public bool isDead;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update ()
	{
		range = Vector2.Distance (transform.position, player.position);

		if (range > maxDistance && !isDead) {
			MoveToward ();
		}
		Rotate ();
	}

	void MoveToward ()
	{
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
	}

	void Rotate ()
	{
		offset = player.transform.position - transform.position;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1));
	}
}
