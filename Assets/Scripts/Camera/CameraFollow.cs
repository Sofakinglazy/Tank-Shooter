using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.2f;
	public Boundary boundary;

	GameObject player;
	Vector3 velocity = Vector3.zero;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		Vector3 cameraPos = transform.position;
		Vector3 playerPos = player.transform.position;

		Vector3 relativeCenter = new Vector3 (0.5f, 0.5f, 10f);

		Vector3 delta = playerPos - Camera.main.ViewportToWorldPoint (relativeCenter);
		Vector3 destination = cameraPos + delta;

		destination.x = Mathf.Clamp (destination.x, boundary.xMin, boundary.xMax);
		destination.y = Mathf.Clamp (destination.y, boundary.yMin, boundary.yMax);

		Debug.Log (destination);

		transform.position = Vector3.SmoothDamp (cameraPos, destination, ref velocity, dampTime);
	}
}


[System.Serializable]
public class Boundary{
	public float xMax;
	public float xMin;
	public float yMax;
	public float yMin;
}
