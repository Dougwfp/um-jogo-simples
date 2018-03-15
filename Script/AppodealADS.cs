using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public class AppodealADS : MonoBehaviour, ISkippableVideoAdListener
{
    public AudioSource eventAudio;

    public AudioClip click;

    public Button verao;
    public Button outono;
    public Button inverno;
    public Button doce;
    // Use this for initialization
    void Start () {
        string appKey = "8f26ba776ad12fbd932651557fb49e189979477bfa9ccaed";
        Appodeal.disableLocationPermissionCheck();       
        Appodeal.setLogging(true);
        //Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
        Appodeal.initialize(appKey,  Appodeal.SKIPPABLE_VIDEO);
        Appodeal.setSkippableVideoCallbacks(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void HabilitaEstacoes()
    {
        eventAudio.PlayOneShot(click);
        if (Appodeal.isLoaded(Appodeal.SKIPPABLE_VIDEO))
        {

            Appodeal.show(Appodeal.SKIPPABLE_VIDEO);
        }
        //verao.interactable = true;
        //outono.interactable = true;
        //inverno.interactable = true;
        //doce.interactable = true;
    }

  
    public void onSkippableVideoLoaded()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        verao.interactable = true;
        outono.interactable = true;
        inverno.interactable = true;
        doce.interactable = true;
        //throw new NotImplementedException();
    }

    public void onSkippableVideoFailedToLoad()
    {

        //throw new NotImplementedException();
    }

    public void onSkippableVideoShown()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        verao.interactable = true;
        outono.interactable = true;
        inverno.interactable = true;
        doce.interactable = true;
        //throw new NotImplementedException();
    }

    public void onSkippableVideoFinished()
    {
        PlayerPrefs.SetInt("maisVida", 1);
        PlayerPrefs.SetInt("monetiza", 0);
        verao.interactable = true;
        outono.interactable = true;
        inverno.interactable = true;
        doce.interactable = true;
        //throw new NotImplementedException();
    }

    public void onSkippableVideoClosed()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        verao.interactable = true;
        outono.interactable = true;
        inverno.interactable = true;
        doce.interactable = true;
        //throw new NotImplementedException();
    }
}
