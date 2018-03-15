using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour {

	GameObject tempEvent;
	public float radiosMin = 5;
	public float radiosMax = 30;

	public Text eventControl;

	public GameController gameController;

	public int totalEventsInGame;
	public int currentEvent = 0;

	public float timeToRespawn;
	private float currentTime;


	public GameObject cactus;
	public GameObject bone;
    public GameObject treeD;
    public GameObject spike;
    public GameObject mushorm;
    public GameObject crystal;


    public GameObject event3;

	public GameObject event4;
	public GameObject event5;
	public GameObject event6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DecreCurrentEvent();
		if (currentEvent < totalEventsInGame)
		{

			if (currentTime > timeToRespawn && gameController.GetCurrentState() == stateMachine.PLAY)
			{
				CreateEvent();
				currentTime = 0;

			}
			else
			{
				currentTime += Time.deltaTime;
			}
		}

	}

	void CreateEvent()
	{
		float random = Random.Range(0, 18);
		if (random <= 4)
		{
            float fase = PlayerPrefs.GetInt("fase");
            if (fase == 0)// normal
            {
                tempEvent = Instantiate(bone.gameObject) as GameObject;
            }
            if (fase == 1)// outono
            {
                tempEvent = Instantiate(mushorm.gameObject) as GameObject;
            }
            if (fase == 2)// inverno
            {
                tempEvent = Instantiate(crystal.gameObject) as GameObject;
            }
            if (fase >= 3)// doce
            {
                tempEvent = Instantiate(spike.gameObject) as GameObject;
            }
            
		}
		if (random >= 5 && random <= 9)
		{
            float fase = PlayerPrefs.GetInt("fase");
            if (fase == 0)// normal
            {
                tempEvent = Instantiate(cactus.gameObject) as GameObject;
            }
            if (fase == 1)// outono
            {
                tempEvent = Instantiate(treeD.gameObject) as GameObject;
            }
            if (fase == 2)// inverno
            {
                tempEvent = Instantiate(treeD.gameObject) as GameObject;
            }
            if (fase >= 3)// doce
            {
                tempEvent = Instantiate(cactus.gameObject) as GameObject;
            }
        }
		if (random >= 10 && random <= 14)
		{
			tempEvent = Instantiate(event3.gameObject) as GameObject;
		}
		if (random == 15)
		{
			tempEvent = Instantiate(event4.gameObject) as GameObject;
		}
		if (random == 16)
		{
			tempEvent = Instantiate(event5.gameObject) as GameObject;
		}
		if (random >= 17)
		{
			tempEvent = Instantiate(event6.gameObject) as GameObject;
		}
		Vector3 newPosition = gameController.transform.position;

		newPosition.x = newPosition.x + Random.Range(Random.Range(radiosMin, radiosMax), Random.Range(-radiosMin, -radiosMax));
		newPosition.z = newPosition.z + Random.Range(Random.Range(radiosMin, radiosMax), Random.Range(-radiosMin, -radiosMax));

		if (random >= 0 && random <= 9)
		{
			newPosition.y = 3.0f;
		}
		if (random >= 10 && random <= 14)
		{
			newPosition.y = -0.1f;
		}

		tempEvent.transform.position = newPosition;


		tempEvent.transform.parent = transform;

		currentEvent++;
	}

	void DecreCurrentEvent()
	{
		if (eventControl.text == "diminui")
		{
			currentEvent--;
			eventControl.text = "destruiu";
		}
	}
}
