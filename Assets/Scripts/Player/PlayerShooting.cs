using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
	public int damage = 10;
	public float timeBetweenShooting = 0.15f;
	public float shootingRange = 100f;
	public float effectDisplayTime = 0.3f;

	float timer;
	Ray shootingRay;
	RaycastHit shootingRayHit;
	int shootableMask;

	LineRenderer gunLine;
	ParticleSystem fireParticle;
	Light gunLight;
	AudioSource gunFireAudio;

	void Start ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");

		gunLine = GetComponent<LineRenderer> ();
		fireParticle = GetComponent<ParticleSystem> ();
		gunLight = GetComponent<Light> ();
		gunFireAudio = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		timer += Time.deltaTime;
		if (Input.GetMouseButton (0) && timer >= timeBetweenShooting) {
			Shoot ();
			timer = 0f;	
		}

		if (timer >= timeBetweenShooting * effectDisplayTime) {
			DisableEffects ();
		}


	}

	void Shoot ()
	{
		Debug.Log ("gun fires.");

		gunFireAudio.Play ();

		fireParticle.Stop ();
		fireParticle.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		shootingRay.origin = transform.position;
		shootingRay.direction = new Vector3 (0, 1f, 0);

		if (Physics.Raycast (shootingRay, out shootingRayHit, shootableMask)) {
			Debug.Log ("Hit shootable mask");
			gunLine.SetPosition (1, shootingRayHit.point);
		} else {
			Debug.Log ("Didnt hit shootable mask");
			gunLine.SetPosition (1, shootingRay.origin + shootingRay.direction * shootingRange);
		}
	}

	void DisableEffects ()
	{
		gunLine.enabled = false;
		gunFireAudio.Stop ();
		fireParticle.Stop ();
	}
}
