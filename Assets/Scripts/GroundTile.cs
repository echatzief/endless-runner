using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawn ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindObjectOfType<GroundSpawn>();
	    Debug.Log(ground);

    }

    private void OnTriggerExit(Collider other){
        ground.SpawnGround();
        Destroy(gameObject,60);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
