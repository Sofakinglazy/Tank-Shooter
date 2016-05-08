using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static int damage = 20;
    public float timeBetweenBullets = 0.3f;
    public float range = 100f;

	public int startAmmo = 50;
	[HideInInspector]
	public int currentAmmo;

	public LayerMask mask;

	public AudioClip shootAudio;
	public AudioClip dryFireAudio;


    float timer;
	Ray2D shootRay;
	RaycastHit2D shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
	AudioSource audioSource;
    float effectsDisplayTime = 0.2f;


    void Start ()
    {
		currentAmmo = startAmmo;

        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunLight = GetComponent<Light> ();
		audioSource = GetComponent<AudioSource> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 )
        {
			timer = 0f;

			if (currentAmmo > 0)
				Shoot ();
			else 
				PlayDryFireEffect ();
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

		currentAmmo--;

		Debug.Log ("Ammo" + currentAmmo);

		audioSource.clip = shootAudio;
        audioSource.Play ();

		PlayFireParticleEffect ();

        gunLine.enabled = true;

		gunLine.SetPosition (0, transform.position);

		Vector3 origin = transform.position;
		Vector3 direction = transform.TransformDirection (new Vector3 (1f, 0, 0)) * range;

		shootHit = Physics2D.Raycast (origin, direction, range, mask.value);

		if(shootHit.collider != null)
        {
			if (shootHit.collider.CompareTag ("Enemy")) {
				GameObject enemy = shootHit.collider.gameObject;
				enemy.GetComponent<EnemyHealth> ().TakeDamage (damage, shootHit.point);
				Debug.Log ("Enemy health: " + enemy.GetComponent<EnemyHealth>().currentHealth);
			}

			if (shootHit.collider.CompareTag ("Barrel")) {
				GameObject barrel = shootHit.collider.gameObject;
				barrel.GetComponent<ExplosiveBarrel> ().TakeDamage (damage);
			}

			gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
			gunLine.SetPosition (1, origin + direction);
        }
    }

	void PlayFireParticleEffect ()
	{
		gunLight.enabled = true;
		gunParticles.Stop ();
		gunParticles.Play ();
	}

	void PlayDryFireEffect(){
		audioSource.clip = dryFireAudio;
		audioSource.Play ();

		PlayFireParticleEffect ();

		Debug.Log ("No ammo left!");
	}

	public void AddAmmo (int ammoAmount){
		currentAmmo += ammoAmount;
		Debug.Log ("current ammo:" + currentAmmo);
	}
}
