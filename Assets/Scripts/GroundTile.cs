using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
	GroundSpawn ground;
	// Start is called before the first frame update
	void Start(){
		ground = GameObject.FindObjectOfType<GroundSpawn>();
	}

	private void OnTriggerEnter(Collider other){
		Debug.Log("Spawn Tile");
		ground.SpawnGround();
	}
	private void OnTriggerExit(Collider other){
		Debug.Log("Destroy Tile");
		Destroy(gameObject,60);
	}
}
