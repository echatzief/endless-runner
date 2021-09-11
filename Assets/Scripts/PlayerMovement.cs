using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private Animator anim;
	public float speed = 5;
	public float horizontalSpeed = 2;
	float horizontalInput;
	public Text distanceText;
	public Text scoreText;
	public Text timeText;
	private float distance = 0.0f;
	Vector3 previousPos;

	public void FixedUpdate() {
		
		// Setup the vertical move
		Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

		// Setup the horizontal move
		Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalSpeed;

		// Get the rigid body and move it
		GameObject player = GameObject.Find("Player");
		if(player){
			Rigidbody playerBody = player.GetComponent<Rigidbody>();
			playerBody.MovePosition(playerBody.position + forwardMove + horizontalMove);
			anim.SetInteger("AnimationPar", 1);
		}
	}

	public void Update() {

		// Get the horizontal input of the keyboard
		horizontalInput = Input.GetAxis("Horizontal");

		// Get the distance between the previous spot and the current
		GameObject player = GameObject.Find("Player");
		Rigidbody playerBody = player.GetComponent<Rigidbody>();
		distance = (distance + Vector3.Distance(playerBody.position, previousPos));

		// Update the distance text
		distanceText.text = string.Format("{0:#0.00} m", distance/100f);

		// Set the current position as previous
		previousPos = playerBody.position;

		// Setup the time
		timeText.text = string.Format("{0:#0} s", (distance/(speed * Time.fixedDeltaTime))/40f);

		// Setup the score
		scoreText.text = string.Format("{0:#0.0} ",(distance/100f) *  ((distance/(speed * Time.fixedDeltaTime))/40f));
	}

	public void Start(){
		GameObject player = GameObject.Find("Player");
		anim = player.GetComponentInChildren<Animator>();
		Debug.Log(anim);

		// Setup the initial distance text
		distanceText.text = distance.ToString()+" m";

		// Initial the spot that the player starts
		Rigidbody playerBody = player.GetComponent<Rigidbody>();
		previousPos = playerBody.position;
	}
}
