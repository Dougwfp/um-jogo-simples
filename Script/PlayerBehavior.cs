using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehavior : MonoBehaviour
{
    public float thrust = 400;
    //public float velocity = 10;
    Rigidbody rb;
    CharacterController cc;

    //public Button jumpButton;


    public PointController pointControl;

    Animator m_Animator;

    public AudioSource playeraudio;

    public AudioSource cameraAudio;

    public AudioSource eventAudio;

    public AudioClip pikup;
    public AudioClip enemyhit;
    public AudioClip enemyhurt;
    public AudioClip speedBust;
    public AudioClip PowerBust;
    public AudioClip normalSong;
    public AudioClip healpotion;
    public AudioClip deathTouch;

    public AudioClip normal;
    public AudioClip outono;
    public AudioClip inverno;
    public AudioClip doce;


    public Text countText;
    public int count;

    public Text lifeText;
    private int life;

    public Text loseText;

    public GameObject PowerupBar;

    public Image barOn;
    public Image barOff;


    public GameObject particulaPower;
    public GameObject particulaSpeed;
    public GameObject particulaPoint;
    public GameObject particulaDano;
    public GameObject particulahit;

    public Text enemyControl;
    //public Animator animator;
    //public Animation animation;

    public float superVelTime;
    public float superpowerTime;

    public float delayVel = 10.0f;
    public float delayPower = 10.0f;

    public float timeToDamage = 2.0f;
    public float delay;

    public float jumpForce = 4000.0F;
    public float gravity = 10.0F;
    public float speed = 7;
    public float rotateSpeed = 400.0f;
    float rechargVel;

    bool velStart;

    Vector3 jump = new Vector3(0.0f, 100.0f, 0.0f);

    private Vector3 moveDirection = Vector3.zero;

    private Vector3 motion = Vector3.zero;

    public GameController gameController;

    private float barOnx;

    void Start()
    {
        playeraudio.volume = PlayerPrefs.GetFloat("som");
        cameraAudio.volume = PlayerPrefs.GetFloat("som");
        eventAudio.volume = PlayerPrefs.GetFloat("som");
        rotateSpeed = PlayerPrefs.GetFloat("giro");
        velStart = false;
        float fase = PlayerPrefs.GetInt("fase");
        if (fase == 0)
        {
            normalSong = normal;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();
        }
        if (fase == 1)
        {
            normalSong = outono;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();
        }
        if (fase == 2)
        {
            normalSong = inverno;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();
        }
        if (fase >= 3)
        {
            normalSong = doce;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();

        }
        
        m_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        life = 300;
        int maisVida = PlayerPrefs.GetInt("maisVida");
        if (maisVida == 1) {
            life = 400;
        }
        SetCountText();

        barOnx = barOn.transform.localScale.x;

    }
    void Update()
    {


        
        if (rechargVel >= 4.0f && gameObject.tag == "Player") {
            speed = 7;
            rechargVel = 0.0f;
            velStart = false;
            //Debug.Log("vel 8");

        }
        if (velStart == true)
        {
            rechargVel = rechargVel + Time.deltaTime;
        }

        if (life == 100) { lifeText.text = "f "; }
        if (life == 200) { lifeText.text = "f f "; }
        if (life == 300) { lifeText.text = "f f f "; }
        if (life == 400) { lifeText.text = "f f f f "; }
        if (life > 400) { life = 400; }
        if (delay < 2.0)
        {
            delay = delay + Time.deltaTime;

        }
        if (delayPower > 0.0)
        {
            barOn.enabled = true;
            barOff.enabled = true;
            delayPower = delayPower - Time.deltaTime;
            barOn.transform.localScale = new Vector3((barOnx * delayPower) / 8.0f, barOn.transform.localScale.y, barOn.transform.localScale.z);
            gameObject.tag = "invenciple";
            speed = 10;

        }

        if (delayPower <= 0.0 && gameObject.tag == "invenciple")
        {
            barOn.enabled = false;
            barOff.enabled = false;
            gameObject.tag = "Player";
            speed = 7;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();
        }

        if (delayVel > 0.0)
        {
            barOn.enabled = true;
            barOff.enabled = true;
            delayVel = delayVel - Time.deltaTime;
            barOn.transform.localScale = new Vector3(1 * delayVel / 8.0f, barOn.transform.localScale.y, barOn.transform.localScale.z);
            gameObject.tag = "Flash";
            speed = 11;


        }
        if (delayVel <= 0.0 && gameObject.tag == "Flash")
        {
            barOn.enabled = false;
            barOff.enabled = false;
            gameObject.tag = "Player";
            speed = 7;
            cameraAudio.clip = normalSong;
            cameraAudio.Play();

        }
        

    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            int idioma = PlayerPrefs.GetInt("idioma");
            life = 50;
            int salvo = PlayerPrefs.GetInt("monetiza");
            PlayerPrefs.SetInt("monetiza", salvo + 1);
            //gravity = 0;
            gameObject.transform.position = gameObject.transform.position;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            cameraAudio.enabled = false;
            lifeText.text = "";
            if (count < 1000)
            {
                loseText.text = "TENTE DE NOVO!!";
                if (idioma == 0) { loseText.text = "TENTE DE NOVO!!"; }
                if (idioma == 1) { loseText.text = "TRY AGAIN!!"; }
            }
                if (count >= 1000)
            {
                
                loseText.text = "AINDA NÃO!!";
                if (idioma == 0) { loseText.text = "AINDA NÃO!!"; }
                if (idioma == 1) { loseText.text = "NOT YET!!"; }
            }
            if (count >= 10000)
            {
                loseText.text = "MELHOROU!!";
                if (idioma == 0) { loseText.text = "TÃO PERTO!!"; }
                if (idioma == 1) { loseText.text = "SO CLOSE!!"; }
            }
            if (count >= 100000)
            {
                loseText.text = "VOCÊ VENCEU!!";
                if (idioma == 0) { loseText.text = "VOCÊ VENCEU!!"; }
                if (idioma == 1) { loseText.text = "YOU WIN!!"; }
                loseText.enabled = true;
                m_Animator.SetFloat("move", 0.0f);
                playeraudio.mute = true;
                if (count > PlayerPrefs.GetInt("record"))
                {
                    PlayerPrefs.SetInt("record", count);
                }
                PlayerPrefs.SetInt("recordActual", count);
                gameController.SwitchState(stateMachine.LOSE);
            }
            loseText.enabled = true;
            m_Animator.SetFloat("move", 0.0f);
            playeraudio.mute = true;
            if (count > PlayerPrefs.GetInt("record"))
            {
                PlayerPrefs.SetInt("record", count);
            }
            PlayerPrefs.SetInt("recordActual", count);
            gameController.SwitchState(stateMachine.LOSE);


        }

    }

    public void Move()
    {

        //cc = GetComponent<CharacterController>();
            
        float moveHorizontal = Input.GetAxis("Horizontal");


        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        
        Vector3 rotation = new Vector3(0.0f, moveHorizontal, 0.0f);

        //rb.AddForce(movement * Time.deltaTime * speed);

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            //rb.AddForce(transform.forward * Time.deltaTime * speed);
            m_Animator.SetFloat("move", 2.0f);

            if (m_Animator.GetFloat("ground") == 0.0f)
            {
                playeraudio.mute = false;
            }

        }
        else
        {
            m_Animator.SetFloat("move", 0.0f);
            playeraudio.mute = true;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * -(speed / 3));
            //rb.AddForce(transform.forward * Time.deltaTime * speed);
            m_Animator.SetFloat("move", 2.0f);
            m_Animator.SetBool("back", true);

            if (m_Animator.GetFloat("ground") == 0.0f)
            {
                //playeraudio.mute = false;
            }
        }
        else
        {
            m_Animator.SetFloat("move", 0.0f);
            playeraudio.mute = true;
        }

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
        rb.transform.Rotate(rotation * Time.deltaTime * rotateSpeed);
        


        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //float curSpeed = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        //rb.MovePosition(forward * curSpeed);
        //cc.Move(forward * curSpeed);
        //m_Animator.SetFloat("move", Input.GetAxis("Vertical"));

        //if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        //{
        //    motion.y = jumpForce;
        //    m_Animator.SetFloat("ground", motion.y);
        //}


        //motion.y -= gravity * Time.deltaTime;
        //m_Animator.SetFloat("ground", motion.y);
        //cc.Move(motion * Time.deltaTime);
        //if (curSpeed > 0 && motion.y < 0)
        //{
        //    audio.mute = false;

        //}
        //else
        //{
        //    audio.mute = true;

        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PikUp"))
        {
            GameObject NovaParticula = Instantiate(particulaPoint);
            NovaParticula.transform.position = other.transform.position;
            Destroy(other.gameObject);
            count = count + 20;
            pointControl.GetComponent<PointController>().pointsQuant--;
            SetCountText();
            eventAudio.PlayOneShot(pikup);

        }
        if (other.gameObject.CompareTag("PikUp1"))
        {
            GameObject NovaParticula = Instantiate(particulaPoint);
            NovaParticula.transform.position = other.transform.position;
            Destroy(other.gameObject);
            count = count + 50;
            pointControl.GetComponent<PointController>().pointsQuant--;
            SetCountText();
            eventAudio.PlayOneShot(pikup);

        }
        if (other.gameObject.CompareTag("PikUp2"))
        {
            GameObject NovaParticula = Instantiate(particulaPoint);
            NovaParticula.transform.position = other.transform.position;
            Destroy(other.gameObject);
            count = count + 100;
            pointControl.GetComponent<PointController>().pointsQuant--;
            SetCountText();
            eventAudio.PlayOneShot(pikup);

        }
        if (other.gameObject.CompareTag("PikUp3"))
        {
            GameObject NovaParticula = Instantiate(particulaPoint);
            NovaParticula.transform.position = other.transform.position;
            Destroy(other.gameObject);
            count = count + 200;
            pointControl.GetComponent<PointController>().pointsQuant--;
            SetCountText();
            eventAudio.PlayOneShot(pikup);

        }
        if (other.gameObject.CompareTag("speed"))
        {
            GameObject NovaParticula = Instantiate(particulaSpeed);
            NovaParticula.transform.position = transform.position;
            NovaParticula.transform.parent = transform;
            eventAudio.PlayOneShot(healpotion);
            cameraAudio.clip = speedBust;
            cameraAudio.Play();
            delayVel = 8.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("power"))
        {
            GameObject NovaParticula = Instantiate(particulaPower);
            NovaParticula.transform.position = transform.position;
            NovaParticula.transform.parent = transform;
            eventAudio.PlayOneShot(healpotion);
            cameraAudio.clip = PowerBust;
            cameraAudio.Play();
            delayPower = 8.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("cure"))
        {
            eventAudio.PlayOneShot(healpotion);
            if (life <= 300)
            {
                life = life + 100;
                GameObject NovaParticula = Instantiate(particulahit);
                NovaParticula.transform.position = transform.position;
                NovaParticula.transform.parent = transform;
                delay = 0;

            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            if (delay > timeToDamage)
            {
                GameObject NovaParticula = Instantiate(particulahit);
                NovaParticula.transform.position = transform.position;
                NovaParticula.transform.parent = transform;
                rb.AddForce(jump * jumpForce);
                other.GetComponent<EnemyBehavior>().destroy = true;
                //Destroy(other.gameObject);
                count = count + 100;
                SetCountText();
                eventAudio.PlayOneShot(enemyhit);
                enemyControl.text = "diminui";
                delay = 0;


            }

            


        }

        if (other.gameObject.CompareTag("death"))
        {
            life = 0;
            eventAudio.PlayOneShot(deathTouch);
        }
        if (other.gameObject.CompareTag("walldeath"))
        {

            gameObject.transform.position = new Vector3(20.9f, 4.63f, 21.2f);
        }

        if (other.gameObject.CompareTag("slow") && gameObject.tag == "Player")
        {
            speed = 4;
            velStart = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("slow") && gameObject.tag == "Player")
        {
            speed = 7;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            m_Animator.SetFloat("ground", 0.0f);
        }
        if (collision.gameObject.CompareTag("enemy") && gameObject.tag != "invenciple")
        {
            if (delay > timeToDamage)
            {
                GameObject NovaParticula = Instantiate(particulaDano);
                NovaParticula.transform.position = transform.position;
                NovaParticula.transform.parent = transform;
                motion.y = jumpForce;
                life = life - 100;
                eventAudio.PlayOneShot(enemyhurt);
                rb.AddForce(jump * jumpForce);
                delay = 0;
            }

        }
        if (collision.gameObject.CompareTag("trap") && gameObject.tag != "invenciple")
        {
            if (delay > timeToDamage)
            {
                GameObject NovaParticula = Instantiate(particulaDano);
                NovaParticula.transform.position = transform.position;
                NovaParticula.transform.parent = transform;
                motion.y = jumpForce;
                life = life - 100;
                eventAudio.PlayOneShot(enemyhurt);
                rb.AddForce(jump * jumpForce);
                delay = 0;
            }

        }
        if (collision.gameObject.CompareTag("trap1") && gameObject.tag != "invenciple")
        {
            if (delay > timeToDamage)
            {
                motion.y = jumpForce;
                life = life - 100;
                eventAudio.PlayOneShot(enemyhurt);
                rb.AddForce(jump * jumpForce);
                delay = 0;
            }

        }
        if (collision.gameObject.CompareTag("enemy") && gameObject.tag == "invenciple")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyBehavior>().destroy = true;
            count = count + 200;
            SetCountText();
            eventAudio.PlayOneShot(enemyhit);
            enemyControl.text = "diminui";
        }
    }
    void SetCountText()
    {
        countText.text = "Pontos : " + count.ToString();
        int idioma = PlayerPrefs.GetInt("idioma");
        if (idioma == 0)
        { countText.text = "Pontos : " + count.ToString(); }
        
        if (idioma == 1)
        { countText.text = "Score : " + count.ToString(); }
    }

        

    public void Jump()
    {
        if (m_Animator.GetFloat("ground") == 0.0f)
        {
            rb.AddForce(jump * jumpForce);
            //rb.MovePosition(transform.position + transform.up * Time.deltaTime * jumpForce);
            m_Animator.SetFloat("ground", 2.0f);
            playeraudio.mute = true;
        }
    }
    public void BTMove()
    {
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            //rb.AddForce(transform.forward * Time.deltaTime * speed);
            m_Animator.SetFloat("move", 2.0f);
            m_Animator.SetBool("back", false);

            if (m_Animator.GetFloat("ground") == 0.0f)
            {
                playeraudio.mute = false;
            }

        }
        if (CrossPlatformInputManager.GetAxis("Vertical") < 0)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * -(speed/3));
            //rb.AddForce(transform.forward * Time.deltaTime * speed);
            m_Animator.SetFloat("move", 2.0f);
            m_Animator.SetBool("back", true);

            if (m_Animator.GetFloat("ground") == 0.0f)
            {
                //playeraudio.mute = false;
            }

        }
        if (CrossPlatformInputManager.GetAxis("Vertical") == 0)
        {
            m_Animator.SetFloat("move", 0.0f);
            playeraudio.mute = true;
        }
        float btmoveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float btmoveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 btrotation = new Vector3(0.0f, btmoveHorizontal, 0.0f);

        rb.transform.Rotate(btrotation * Time.deltaTime * 130);
    }
}
