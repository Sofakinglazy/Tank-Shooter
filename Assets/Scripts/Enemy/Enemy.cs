using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public float speed = 30f;
	public int damage = 5;
	public int maxHealth = 100;
	public float timeBetweenDamage = 0.5f;
	int currentHealth;

	float maxDistance = 20f;
	Transform player;
	float range;
	Vector3 offset;
	float timer;
	bool withinDistance;

	void Start ()
	{
		currentHealth = maxHealth;
		withinDistance = false;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update ()
	{
		range = Vector2.Distance (transform.position, player.position);

		if (range > maxDistance) {
			MoveToward ();
		}

		Rotate ();

		timer += Time.deltaTime;
		if (withinDistance && timer >= timeBetweenDamage) {
			Attack ();
		}

		if (currentHealth <= 0) {
			Death ();
		}
	}

	void MoveToward ()
	{
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
	}

	void Rotate ()
	{
		offset = player.transform.position - transform.position;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1));
	}

	void Attack (){
		player.SendMessage ("TakeDamage", damage);
		timer = 0;
	}

	void Death ()
	{
		Debug.Log ("Enermy dead!");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			withinDistance = true;
		}
	}
}
