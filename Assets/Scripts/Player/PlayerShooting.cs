using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static int damagePerShot = 20;
    public float timeBetweenBullets = 0.3f;
    public float range = 500f;


    float timer;
    Ray2D shootRay;
    RaycastHit2D shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
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
		gunLine.SetPosition (0, Vector3.zero);

		shootRay.origin = Vector3.zero;
		shootRay.direction = new Vector3(0, 1f, 0);

		Debug.Log (transform.up);

		shootHit = Physics2D.Raycast (shootRay.origin, shootRay.direction, range, shootableMask);

		if(shootHit.collider != null)
        {
			Debug.Log ("Hit the shootable mask");
			gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
			Debug.Log ("Didnt hit the shootable mask");
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
