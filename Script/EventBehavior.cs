using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBehavior : MonoBehaviour
{

    public float speedMove;

    public Text control;

    public float timeToChange;

    public float timeToDestroy = 15;
    public float currentTime = 0;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {

        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DestroySelf();

        //if (gameController.GetCurrentState() != stateMachine.PLAY)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void Update()
    {

        //if (gameObject.tag == "trap1")
        //{
        //    Debug.Log("trap1");
        //    timeToChange -= Time.deltaTime;
        //    if (timeToChange <= 0.0f)
        //    {
        //        gameObject.tag = "trap";
        //    }
        //}
        //if (gameObject.tag == "trap" && timeToChange != 2.0f)
        //{
        //    timeToChange = 2.0f;
        //}
    }
    public void DestroySelf()
    {

        if (control.text == "destruiu")
        {
            control.text = "";
            Destroy(gameObject);
        }

        if (gameObject.tag == "trap" || gameObject.tag == "trap1" || gameObject.tag == "slow")
        {
            timeToDestroy = 45;
        }

        if (currentTime > timeToDestroy)
        {

            control.text = "diminui";
            //Debug.Log("destruiu");
            currentTime = 0;


        }
        else
        {
            currentTime += Time.deltaTime;
        }

    }

}
