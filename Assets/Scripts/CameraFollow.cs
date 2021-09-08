using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	GameObject player;
	Transform playerTransform;
	Vector3 offset; 
	
	void Start(){

		// Find the player and the transform of the player
		player = GameObject.Find("Player");
		playerTransform = player.GetComponent<Transform>();

		// Initialize the offset
		offset = transform.position - playerTransform.position;
	}

	void Update(){

		// Update the camera position
		Vector3 newPosition = playerTransform.position + offset;
		newPosition.x = 0;
		transform.position = newPosition;
	}
}
