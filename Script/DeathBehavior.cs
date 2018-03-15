using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehavior : MonoBehaviour {

    public float speedMove;

    private GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

    }
	
	// Update is called once per frame
	void Update () {

        if (gameController.GetCurrentState() == stateMachine.PLAY)
        {
            //enemy action

            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
            Vector3 playerposit = new Vector3(gameController.player.transform.position.x, gameController.player.transform.position.y, gameController.player.transform.position.z);
            transform.LookAt(playerposit);
            transform.Rotate(0, 0, 0);

        }
        //if (gameController.GetCurrentState() == stateMachine.LOSE)
        //{
        //    Destroy(gameObject);
        //}
    }
}
