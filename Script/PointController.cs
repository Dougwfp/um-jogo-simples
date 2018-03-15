using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    Transform tempPoint;
    public Transform pointPrefab;
    public Transform pointPrefab1;
    public Transform pointPrefab2;
    public Transform pointPrefab3;
    public float radiusSpawn;

    public GameController gameController;

    public float timetoDecree = 0.0f;
    public Text control;

    public int maxPoints = 20;
    public int pointsQuant = 0;

    public float timeToRespawn = 1;
    private float currentTime;
    // Use this for initialization
    void Start()
    {
        maxPoints = 20;
        pointsQuant = 0;
        timeToRespawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetCurrentState() == stateMachine.PLAY)
        {
            //DestroyForText();
            SpawnControll();
            DecreeForTime();
            
        }
    }

    public Transform SpawnPoint()
    {
        float random = Random.Range(0, 13);
        if (random <= 4)
        {
            tempPoint = Instantiate(pointPrefab) as Transform;
        }
        if (random >= 5 && random <= 8)
        {
            tempPoint = Instantiate(pointPrefab1) as Transform;
        }
        if (random >= 9 && random <= 11)
        {
            tempPoint = Instantiate(pointPrefab2) as Transform;
        }
        if (random >= 12)
        {
            tempPoint = Instantiate(pointPrefab3) as Transform;
        }
        
        Vector3 newPosition = transform.position;
        newPosition.x += Random.Range(-radiusSpawn, radiusSpawn);
        newPosition.z += Random.Range(-radiusSpawn, radiusSpawn);

        tempPoint.transform.position = newPosition;

        tempPoint.transform.parent = transform;

        return tempPoint;


    }
    public void LessPointsQuant()
    {
        pointsQuant--;
    }
    void DestroyForText()
    {
        if (control.text == "destruiu")
        {
            LessPointsQuant();
            control.text = "";
        }
    }
    void SpawnControll()
    {
        if (currentTime > timeToRespawn)
        {

            if (pointsQuant < maxPoints)
            {
                SpawnPoint();
                pointsQuant++;
                currentTime = 0;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
    void DecreeForTime()
    {
        if (timetoDecree >= 5.0f)
        {
            pointsQuant--;
            timetoDecree = 0.0f;
        }
        else
        {
            timetoDecree = timetoDecree + Time.deltaTime;
        }
    }
}
