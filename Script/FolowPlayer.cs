using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x, Mathf.Clamp(player.position.y, 5, 20), player.position.z - 5);
        /*new Vector3(Mathf.Clamp(player.position.x,10,30));*/
    }
}
