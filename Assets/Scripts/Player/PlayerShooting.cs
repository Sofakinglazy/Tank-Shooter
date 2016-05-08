using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static int damagePerShot = 20;
    public float timeBetweenBullets = 0.3f;
    public float range = 100f;

	public LayerMask mask;

    float timer;
	Ray2D shootRay;
	RaycastHit2D shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;

		gunLine.SetPosition (0, transform.position);

		Vector3 origin = transform.position;
		Vector3 direction = transform.TransformDirection (new Vector3 (1f, 0, 0)) * range;

		shootHit = Physics2D.Raycast (origin, direction, range, mask.value);

		if(shootHit.collider != null)
        {
			
			Debug.Log ("Hit the shootable mask");

			if (shootHit.collider.CompareTag ("Alive")) {
				Debug.Log ("That is an enemy.");
			}

			gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
			gunLine.SetPosition (1, origin + direction);
        }
    }
}
