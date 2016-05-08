using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Boundary boundary;

	Rigidbody2D rg2d;
//	float alterDegree = -90f; //To make the tank face to x axis

	void Start (){
		rg2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Move(x, y);

		float mouseX = Input.mousePosition.x; 
		float mouseY = Input.mousePosition.y;

		Rotate(mouseX, mouseY);
	}

	void Move(float x, float y){
		Vector3 movement = new Vector3 (x, y, 0);
		movement = movement.normalized * speed * Time.deltaTime;
		Vector3 destination = transform.position + movement;

		destination.x = Mathf.Clamp (destination.x, boundary.xMin, boundary.xMax);
		destination.y = Mathf.Clamp (destination.y, boundary.yMin, boundary.yMax);

		rg2d.MovePosition (destination);
	}
		
	void Rotate(float x, float y){
		Vector3 mousePos = new Vector3 (x, y, 0);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		Vector3 diff = mousePos - transform.position;
		float angle = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

}
