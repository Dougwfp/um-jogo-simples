using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	GameObject tempEnemy;
	public float radiosMin = 5;
	public float radiosMax = 30;
    public float timetodecree = 0.0f;
    public Text enemyControl;

	public GameController gameController;

	public int totalEnemysInGame;
	public int currentEnemys = 0;

	public float timeToRespawn;
	private float currentTime;


	public EnemyBehavior enemy;
	public EnemyBehavior enemy2;
	public EnemyBehavior enemy3;
	public EnemyBehavior enemy4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoreEnemys();
		//DecreCurrentEnemys();

        if (gameController.player.GetComponent<PlayerBehavior>().count <= 1000)
        {
            totalEnemysInGame = 5;
        }
        if (gameController.player.GetComponent<PlayerBehavior>().count >= 1001 && gameController.player.GetComponent<PlayerBehavior>().count <= 2500)
        {
            totalEnemysInGame = 10;
        }
        if (gameController.player.GetComponent<PlayerBehavior>().count >= 2501 && gameController.player.GetComponent<PlayerBehavior>().count <= 5000)
        {
            totalEnemysInGame = 15;
        }
        if (gameController.player.GetComponent<PlayerBehavior>().count >= 5001)
        {
            totalEnemysInGame = 20;
        }




        if (currentEnemys < totalEnemysInGame) {

			if (currentTime > timeToRespawn && gameController.GetCurrentState() == stateMachine.PLAY)
			{
				CreateEnemy();
				currentTime = 0;

			}
			else
			{
				currentTime += Time.deltaTime;
			}
		}
		
		
	}

	void CreateEnemy() {

		float random = Random.Range(0, 4);
		if (random == 0 ) {
			tempEnemy = Instantiate(enemy.gameObject) as GameObject;
		}
		if (random == 1)
		{
			tempEnemy = Instantiate(enemy2.gameObject) as GameObject;
		}
		if (random == 2)
		{
			tempEnemy = Instantiate(enemy3.gameObject) as GameObject;
		}
		if (random >= 3 )
		{
			tempEnemy = Instantiate(enemy4.gameObject) as GameObject;
		}
		Vector3 newPosition = gameController.transform.position;

		newPosition.x = newPosition.x + Random.Range(Random.Range(radiosMin, radiosMax), Random.Range(-radiosMin, -radiosMax));
		newPosition.z = newPosition.z + Random.Range(Random.Range(radiosMin, radiosMax),Random.Range(-radiosMin, -radiosMax));
		//newPosition.y = newPosition.y * 0;
		tempEnemy.transform.position = newPosition;
		 

		tempEnemy.transform.parent = transform;

		currentEnemys++;

	}
	//void DecreCurrentEnemys()
	//{
	//	if (enemyControl.text == "diminui")
	//	{
	//		currentEnemys--;
	//		enemyControl.text = "destruiu";
	//	}
	//}
    void MoreEnemys()
    {
        if (timetodecree >= 120.0f)
        {
            currentEnemys--;
            timetodecree = 0.0f;

        }
        else
        {
            timetodecree = timetodecree + Time.deltaTime;
        }
    }
}
