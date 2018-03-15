using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehavior : MonoBehaviour
{

    public PointController controller;
    public GameController gameController;
    public PlayerBehavior player;
    public Mesh normal;
    public Mesh outono;
    public Mesh inverno;
    public Mesh doce;
    public Text control;

    public float speedMove;

    public float timeToDestroy = 15;
    public float currentTime = 0;

    // Use this for initialization
    void Start()
    {
        controller = FindObjectOfType(typeof(PointController)) as PointController;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        player = FindObjectOfType(typeof(PlayerBehavior)) as PlayerBehavior;
        float fase = PlayerPrefs.GetInt("fase");
        if (fase == 0)
        {
            GetComponent<MeshFilter>().mesh = normal;
        }
        if (fase == 1)
        {
            GetComponent<MeshFilter>().mesh = outono;
        }
        if (fase == 2)
        {
            GetComponent<MeshFilter>().mesh = inverno;
        }
        if (fase >= 3)
        {
            GetComponent<MeshFilter>().mesh = doce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetCurrentState() == stateMachine.PLAY)
        {

            //enemy action
            if (player.tag == "Flash")
            {
                gameObject.GetComponent<rotate>().enabled = false;
                transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
                Vector3 playerposit = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(playerposit);
                transform.Rotate(0, 0, 0);
            }
            else {
                gameObject.GetComponent<rotate>().enabled = true;
            }

            DestroySelf();
        }
        else {
            Destroy(gameObject);
        }
    }
    public void DestroySelf()
    {

        if (currentTime > timeToDestroy)
        {
            controller.GetComponent<PointController>().pointsQuant--;
            //control.text = "destruiu";
            //Debug.Log("destruiu");
            currentTime = 0;
            Destroy(gameObject);

        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
