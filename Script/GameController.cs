using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public enum stateMachine
{
    START,
    RELOAD,
    PAUSED,
    PLAY,
    WIN,
    LOSE,
    NULL

}

public class GameController : MonoBehaviour//, IBannerAdListener
{
    public PointBehavior points;
    public PointController pointController;
    //public Material madeiraTerra;
    //public Material madeira2;
    //public Material pantaArvore;
    //public Material pantas;
    //public Material chao;
    //public Material flor1;
    //public Material musgo;
    //public Material cogumelo1;
    //public Material pedra;
    public PlayerBehavior player;
    private stateMachine currentState = stateMachine.START;
    private stateMachine lastState = stateMachine.NULL;
    private Transform currentPoint;
    public float count;

    // Use this for initialization
    void Start()
    {

        string appKey = "8f26ba776ad12fbd932651557fb49e189979477bfa9ccaed";
        Appodeal.disableLocationPermissionCheck();
        //Appodeal.setBannerCallbacks(this);
        Appodeal.setLogging(true);
        //Appodeal.confirm(Appodeal.BANNER);
        Appodeal.initialize(appKey, Appodeal.BANNER);

        ShowBanner();


        
        //float fase = PlayerPrefs.GetInt("fase");
        //if (fase == 0)// normal
        //{
        //    madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
        //    madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
        //    pantaArvore.color = Color.HSVToRGB(0.4f, 0.5f, 0.5f);//verde arvore
        //    pantas.color = Color.HSVToRGB(0.4f, 0.7f, 0.7f);//verde claro
        //    chao.color = Color.HSVToRGB(0.4f, 0.6f, 0.6f);//verde claro chao
        //    flor1.color = Color.HSVToRGB(0.0f, 0.42f, 0.6f);//marrom desbotado
        //    musgo.color = Color.HSVToRGB(0.4f, 0.8f, 0.8f);//verde muito claro
        //    cogumelo1.color = Color.HSVToRGB(0.16f, 0.40f, 1.0f);//amarelo desbotado
        //    pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        //}
        //if (fase == 1)// outono
        //{
        //    madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        //    madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        //    pantaArvore.color = Color.HSVToRGB(0.0f, 1.0f, 0.2f);//vermelho escuro
        //    pantas.color = Color.HSVToRGB(0.088f, 0.85f, 0.8f);//laranja
        //    chao.color = Color.HSVToRGB(0.16f, 0.86f, 0.6f);//amarelo escuro
        //    flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
        //    musgo.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
        //    cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 0.9f);//amarelo
        //    pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        //}
        //if (fase == 2)// inverno
        //{
        //    madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        //    madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        //    pantaArvore.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        //    pantas.color = Color.HSVToRGB(0.1f, 0.25f, 0.95f);//cor de pele muito claro
        //    chao.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
        //    flor1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        //    musgo.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
        //    cogumelo1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        //    pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        //}
        //if (fase >= 3)// doce
        //{
        //    madeiraTerra.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
        //    madeira2.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
        //    pantaArvore.color = Color.HSVToRGB(0.84f, 0.60f, 0.99f);//rosa
        //    pantas.color = Color.HSVToRGB(0.5f, 0.84f, 0.82f);//azul calro
        //    chao.color = Color.HSVToRGB(0.6f, 1.0f, 0.7f);//azul escuro
        //    flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
        //    musgo.color = Color.HSVToRGB(0.7f, 0.5f, 0.5f);//roxo
        //    cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 1.0f);//amarelo
        //    pedra.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
        //}

        currentPoint = pointController.SpawnPoint();
    }

    public void ShowBanner()
    {
        if (Appodeal.isLoaded(Appodeal.BANNER))
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
    }
    public void HideBanner()
    {
        Appodeal.hide(Appodeal.BANNER);
    }    
    //Update is called once per frame
    void Update()
    {
        

        GameStateMachine();

        if (currentState == stateMachine.LOSE)
        {


            if (count >= 3.0f)
            {
                count = 0.0f;
                SceneManager.LoadScene("Menu");

            }

            else
            {
                count = count + Time.deltaTime;
            }

        }



    }

    public void SwitchState(stateMachine nextState)
    {
        lastState = currentState;
        currentState = nextState;

    }

    void GameStateMachine()
    {


        switch (currentState)
        {
            case stateMachine.START:
                {
                    SwitchState(stateMachine.PLAY);
                }
                break;
            case stateMachine.RELOAD:
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
            case stateMachine.PAUSED:
                {
                    //input
                    BasicInputs();
                }
                break;
            case stateMachine.PLAY:
                {
                    

                    player.Move();
                    player.BTMove();
                    //input
                    BasicInputs();
                }
                break;
            case stateMachine.WIN:
                {
                    //input
                    BasicInputs();


                }
                break;
            case stateMachine.LOSE:
                {
                    //input
                }
                break;
            case stateMachine.NULL:
                {

                }
                break;
        }


    }

    public stateMachine GetCurrentState()
    {
        return currentState;
    }
    void BasicInputs()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PLAY)
        {
            SwitchState(stateMachine.LOSE);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PAUSED)
        {
            SwitchState(stateMachine.PLAY);
        }


    }

    //public void onBannerLoaded()
    //{
    //    throw new NotImplementedException();
    //}

    //public void onBannerFailedToLoad()
    //{
    //    throw new NotImplementedException();
    //}

    //public void onBannerShown()
    //{
    //    throw new NotImplementedException();
    //}

    //public void onBannerClicked()
    //{
    //    throw new NotImplementedException();
    //}
}
