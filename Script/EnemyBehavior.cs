using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyBehavior : MonoBehaviour
{
    public float speedMove;

    Rigidbody rb;

    public Text control;

    public Animator m_Animator;

    public bool destroy = false;

    public float timetodestroy = 0.0f;

    private GameController gameController;

    private EnemyController enemycontroller;

    bool vel1 = false;
    bool vel2 = false;
    bool vel3 = false;
    bool vel4 = false;

    // Use this for initialization
    void Start()
    {
        enemycontroller = FindObjectOfType(typeof(EnemyController)) as EnemyController;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rb = GetComponent<Rigidbody>();
        //if (gameObject.name == "Enemy(Clone)")
        //{
        //    float ramdom = Random.Range(0.0f, 3.0f);
        //    if (ramdom >= 2.0f)
        //    {

        //        //speedMove = speedMove * 1.1f;
        //    }
        //}
        //if (gameObject.name == "Enemy2(Clone)")
        //{
        //    float ramdom = Random.Range(0.0f, 3.0f);
        //    if (ramdom >= 2.0f)
        //    {

        //        //speedMove = speedMove * 1.1f;
        //    }
        //}


    }

    // Update is called once per frame

    //public void DestroySelf()
    //{

    //    if (control.text == "destruiu")
    //    {
    //        control.text = "";
    //        destroy = true;
    //        Destroy(gameObject);
    //    }

    //}

    private void Update()
    {
        if (gameController.GetCurrentState() == stateMachine.PLAY)
        {

            if (gameController.player.GetComponent<PlayerBehavior>().count <= 1000)
            {
                if (vel1 == false)
                {

                    vel1 = true;
                    speedMove = 3.5f;
                }

            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 1001 && gameController.player.GetComponent<PlayerBehavior>().count <= 2500)
            {
                if (vel2 == false)
                {

                    vel2 = true;
                    speedMove = 4.0f;

                }
            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 2501 && gameController.player.GetComponent<PlayerBehavior>().count <= 5000)
            {
                if (vel3 == false)
                {

                    vel3 = true;
                    speedMove = 4.5f;

                }
            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 5001)
            {
                if (vel4 == false)
                {

                    vel4 = true;
                    speedMove = 5.0f;

                }
            }

            //enemy action
            if (gameController.player.tag == "Player")
            {
                transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
                Vector3 playerposit = new Vector3(gameController.player.transform.position.x, transform.position.y, gameController.player.transform.position.z);
                transform.LookAt(playerposit);
                transform.Rotate(0, 0, 0);
            }
            if (gameController.player.tag == "Flash")
            {
                transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
                Vector3 playerposit = new Vector3(gameController.player.transform.position.x, transform.position.y, gameController.player.transform.position.z);
                transform.LookAt(playerposit);
                transform.Rotate(0, 0, 0);
            }
            if (gameController.player.tag == "invenciple")
            {
                transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
                Vector3 playerposit = new Vector3(gameController.player.transform.position.x, transform.position.y, gameController.player.transform.position.z);
                transform.LookAt(playerposit);
                transform.Rotate(0, 180, 0);

            }
            //DestroySelf();

            if (destroy == true)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                m_Animator.SetBool("dead", true);
                speedMove = 0.0f;
                if (timetodestroy >= 1.0f)
                {
                    timetodestroy = 0.0f;
                    destroy = false;
                    Destroy(gameObject);
                }
                else
                {

                    timetodestroy = timetodestroy + Time.deltaTime;
                }
            }

        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            //control.text = "diminui";
            enemycontroller.currentEnemys = enemycontroller.currentEnemys - 1;
            destroy = true;
            //collision.gameObject.tag = "trap1";
            //Destroy(gameObject);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("walldeath"))
        {
            //control.text = "diminui";
            destroy = true;
            enemycontroller.currentEnemys = enemycontroller.currentEnemys - 1;
            //collision.gameObject.tag = "trap1";
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("slow"))
        {
            if (gameController.player.GetComponent<PlayerBehavior>().count <= 1000)
            {
                speedMove = 1.5f;

            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 1001 && gameController.player.GetComponent<PlayerBehavior>().count <= 2500)
            {
                speedMove = 1.75f;

            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 2501 && gameController.player.GetComponent<PlayerBehavior>().count <= 5000)
            {
                speedMove = 2.0f;
            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 5001)
            {
                speedMove = 2.25f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("slow"))
        {
            if (gameController.player.GetComponent<PlayerBehavior>().count <= 1000)
            {
                speedMove = 3.5f;

            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 1001 && gameController.player.GetComponent<PlayerBehavior>().count <= 2500)
            {
                speedMove = 4.0f;

            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 2501 && gameController.player.GetComponent<PlayerBehavior>().count <= 5000)
            {
                speedMove = 4.5f;
            }
            if (gameController.player.GetComponent<PlayerBehavior>().count >= 5001)
            {
                speedMove = 5.0f;
            }
        }
    }

}
