using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundSpawn : MonoBehaviour
{
	public GameObject ground;
	public GameObject obstacle;
	Vector3 nextSpawnPoint;
	Vector3[] obstaclesArray = new Vector3[40];
	int obstaclesAdded = 0;

	public void SpawnGround(){
		Debug.Log("Spawn Tile");
		Debug.Log(transform.position);
		nextSpawnPoint = transform.position;
		nextSpawnPoint.z = transform.position.z + 200;
		Debug.Log(nextSpawnPoint);
		Instantiate(ground,nextSpawnPoint, Quaternion.identity);
	}

	void SpawnObstacles(){
		for(int i = 0; i < 40; i++){
			Vector3 obstaclePos = new Vector3(
				Random.Range(-8,8),
				Random.Range(0,0),
				Random.Range(transform.position.z+1,transform.position.z+200)
			);
			
			if (!obstaclesArray.Contains(obstaclePos)) {
				obstaclesArray[obstaclesAdded] = obstaclePos;
				obstaclesAdded+=1;
				Instantiate(obstacle,obstaclePos, Quaternion.identity);
 			}
		}
	}

	void Start(){
		//SpawnObstacles();
	}
}
