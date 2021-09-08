using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;
	public float horizontalSpeed = 2;
	float horizontalInput;

	public void FixedUpdate() {
		
		// Setup the vertical move
		Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

		// Setup the horizontal move
		Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalSpeed;

		// Get the rigid body and move it
		GameObject player = GameObject.Find("Player");
		Rigidbody playerBody = player.GetComponent<Rigidbody>();
		playerBody.MovePosition(playerBody.position + forwardMove + horizontalMove);
	}

	public void Update() {

		// Get the horizontal input of the keyboard
		horizontalInput = Input.GetAxis("Horizontal");
	}
}
