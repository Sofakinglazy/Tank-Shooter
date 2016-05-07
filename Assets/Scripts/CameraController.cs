using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Zombie;
	Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - Zombie.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Zombie.transform.position + offset;
	}
}
