using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

using System;

//using UnityEngine.Advertisements;

public class Menu : MonoBehaviour, ISkippableVideoAdListener
{
    int monetiza;
    // android 1419561
    // ios 1419560
    public Text recodText;
    public Text recodActualText;
    public Text MenuText;
    public Text HistText;
    public Text obsText;
    public Text faseText;
    public Text idiomaText;
    public Text veraoText;
    public Text outonoText;
    public Text invernoText;
    public Text doceText;


    bool modifica = false;
    public Slider som;
    public Slider move;

    public AudioSource eventAudio;

    public AudioClip click;

    public Material madeiraTerra;
    public Material madeira2;
    public Material pantaArvore;
    public Material pantas;
    public Material chao;
    public Material flor1;
    public Material musgo;
    public Material cogumelo1;
    public Material pedra;


    int intmod = 0;
    //bool menu1;
    //bool menu2;
    //bool menu3;

    public ScrollRect scrollRect;
    public ScrollRect scrollRect2;
    public ScrollRect scrollRect3;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("maisVida", 0);
        //PlayerPrefs.SetInt("monetiza", 0);
        intmod = PlayerPrefs.GetInt("modifica");
        som.value = 0.5f;
        move.value = 350;
        if (intmod >= 1)
        {
            Debug.Log(intmod);
            som.value = PlayerPrefs.GetFloat("som");
            move.value = PlayerPrefs.GetFloat("giro");
        }
        if (intmod == 0)
        {

            PlayerPrefs.SetFloat("som", 0.5f);
            PlayerPrefs.SetFloat("giro", 350);

        }
        //menu1 = false;
        //menu2 = false;
        //menu3 = false;
        monetiza = PlayerPrefs.GetInt("monetiza");
        String appKey = "8f26ba776ad12fbd932651557fb49e189979477bfa9ccaed";
        Appodeal.disableLocationPermissionCheck();
        //Appodeal.setInterstitialCallbacks(this);
        Appodeal.setLogging(true);
        Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
        Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO | Appodeal.SKIPPABLE_VIDEO);
        Appodeal.setSkippableVideoCallbacks(this);
        if (monetiza >= 5)
        {
            if (Appodeal.isLoaded(Appodeal.SKIPPABLE_VIDEO))
            {

                Appodeal.show(Appodeal.SKIPPABLE_VIDEO);
            }
            monetiza = 0;
            PlayerPrefs.SetInt("monetiza", 0);
        }

        Score();
        int random = UnityEngine.Random.Range(0, 4);
        PlayerPrefs.SetInt("fase", random);
        float fase = PlayerPrefs.GetInt("fase");
        if (fase == 0)// normal
        {
            madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
            madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
            pantaArvore.color = Color.HSVToRGB(0.4f, 0.5f, 0.5f);//verde arvore
            pantas.color = Color.HSVToRGB(0.4f, 0.7f, 0.7f);//verde claro
            chao.color = Color.HSVToRGB(0.4f, 0.6f, 0.6f);//verde claro chao
            flor1.color = Color.HSVToRGB(0.0f, 0.42f, 0.6f);//marrom desbotado
            musgo.color = Color.HSVToRGB(0.4f, 0.8f, 0.8f);//verde muito claro
            cogumelo1.color = Color.HSVToRGB(0.16f, 0.40f, 1.0f);//amarelo desbotado
            pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        }
        if (fase == 1)// outono
        {
            madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
            madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
            pantaArvore.color = Color.HSVToRGB(0.0f, 1.0f, 0.2f);//vermelho escuro
            pantas.color = Color.HSVToRGB(0.088f, 0.85f, 0.8f);//laranja
            chao.color = Color.HSVToRGB(0.16f, 0.86f, 0.6f);//amarelo escuro
            flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
            musgo.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
            cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 0.9f);//amarelo
            pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        }
        if (fase == 2)// inverno
        {
            madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
            madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
            pantaArvore.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
            pantas.color = Color.HSVToRGB(0.1f, 0.25f, 0.95f);//cor de pele muito claro
            chao.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
            flor1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
            musgo.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
            cogumelo1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
            pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
        }
        if (fase >= 3)// doce
        {
            madeiraTerra.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
            madeira2.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
            pantaArvore.color = Color.HSVToRGB(0.84f, 0.60f, 0.99f);//rosa
            pantas.color = Color.HSVToRGB(0.5f, 0.84f, 0.82f);//azul calro
            chao.color = Color.HSVToRGB(0.6f, 1.0f, 0.7f);//azul escuro
            flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
            musgo.color = Color.HSVToRGB(0.7f, 0.5f, 0.5f);//roxo
            cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 1.0f);//amarelo
            pedra.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
        }

    }

    public void IdiomaEng()
    {
        PlayerPrefs.SetInt("idioma", 1);
        recodText.text = "Highest      Score                " + PlayerPrefs.GetInt("record").ToString();
        recodActualText.text = "Last           Score            " + PlayerPrefs.GetInt("recordActual").ToString();
        MenuText.text = "Simple Game";
        HistText.text = "The evil witch captured Princess Red, and with boredom and disbelief that the princess might one day offer him some trouble, she offered to participate in a simple game." +
"In an extra planar area, Red needs to collect the points (Food) and survive the traps and enemies to be able to break free.\n\n" +
"Take the food, run away or jump on enemies' heads.\n\n" +
"Get the PowerUps and try to get as many points as you can, so maybe Princess Red can break free of this game.\n\n" +
"\n Note: \n\n" +
"Watch out for the white spirit, if you touch it you will lose!";
        obsText.text = "Thanks:\n\n" +
"Lara Bueno.\n" +
"Vivian Lino.\n" +
"Marcos Paulo.\n" +
"Luiz Carlos.\n" +
"Lucas Ciminelli (Divy).\n\n" +
"Assets Usados:\n\n" +
"Unity Assets;\n\n" +
"- AxeyWorks\n" +
"- Fantasy Skybox\n" +
"- Free Food Pack\n" +
"- Haruko\n" +
"- Lv1 Monster Pack\n" +
"- Low Poly Weapons\n\n" +
"Sounds / letters\n\n" +
"- opengameart.org\n" +
"- dafont.com\n" +
"- freesound.org\n";
        faseText.text = "To choose the next Weather click the button above and watch the advertisement!";
        idiomaText.text = "Language";
        veraoText.text = "SUMMER";
        outonoText.text = "AUTUMN";
        invernoText.text = "WINTER";
        doceText.text = "CANDY";
    }
    public void IdiomaBr()
    {
        PlayerPrefs.SetInt("idioma", 0);

        recodText.text = "Maior      Pontuação                " + PlayerPrefs.GetInt("record").ToString();
        recodActualText.text = "Última   Pontuação                  " + PlayerPrefs.GetInt("recordActual").ToString();
        MenuText.text = "Um Jogo Simples";
        HistText.text = "A bruxa malvada capturou a princesa Red e com tédio e descrença de que a princesa um dia sequer poderia lhe oferecer algum problema, ela lhe ofereceu participar de um jogo simples." +
"Em uma área extra planar Red precisa pegar os pontos(Comidas)e sobreviver as armadilhas e inimigos para conseguir se libertar.\n\n" +
"Pegue as comidas, fuja ou pule na cabeça dos inimigos.\n\n" +
"Pegue os PowerUps e tente conseguir o máximo de pontos que puder, e assim talvez a princesa Red consiga se libertar deste jogo.\n\n" +
"\n Obs: \n\n" +
"Cuidado com o espirito branco, você vai perder se tocar nele.";
        obsText.text = "Agradecimentos:\n\n" +
"Lara Bueno.\n" +
"Vivian Lino.\n" +
"Marcos Paulo.\n" +
"Luiz Carlos.\n" +
"Lucas Ciminelli (Divy).\n\n" +
"Assets Usados:\n\n" +
"Unity Assets;\n\n" +
"- AxeyWorks\n" +
"- Fantasy Skybox\n" +
"- Free Food Pack\n" +
"- Haruko\n" +
"- Lv1 Monster Pack\n" +
"-Low Poly Weapons\n\n" +
"Sons / Letras\n\n" +
"- opengameart.org\n" +
"- dafont.com\n" +
"- freesound.org\n";
        faseText.text = "Para Escolher a proxima fase clique no botão acima e assista a propaganda!";
        idiomaText.text = "Idioma";
        veraoText.text = "VERÃO";
        outonoText.text = "OUTONO";
        invernoText.text = "INVERNO";
        doceText.text = "DOCE";



    }

    // Update is called once per frame
    void Update()
    {


    }

    void Score()
    {
        int idioma = PlayerPrefs.GetInt("idioma");
        recodText.text = "Maior      Pontuação                " + PlayerPrefs.GetInt("record").ToString();
        recodActualText.text = "Última   Pontuação                  " + PlayerPrefs.GetInt("recordActual").ToString();
        MenuText.text = "Um Jogo Simples";
        HistText.text = "A bruxa malvada capturou a princesa Red e com tédio e descrença de que a princesa um dia sequer poderia lhe oferecer algum problema, ela lhe ofereceu participar de um jogo simples." +
"Em uma área extra planar Red precisa pegar os pontos(Comidas)e sobreviver as armadilhas e inimigos para conseguir se libertar.\n\n" +
"Pegue as comidas, fuja ou pule na cabeça dos inimigos.\n\n" +
"Pegue os PowerUps e tente conseguir o máximo de pontos que puder, e assim talvez a princesa Red consiga se libertar deste jogo.\n\n" +
"\n Obs: \n\n" +
"Cuidado com o espirito branco, você vai perder se tocar nele.";
        obsText.text = "Agradecimentos:\n\n" +
"Lara Bueno.\n" +
"Vivian Lino.\n" +
"Marcos Paulo.\n" +
"Luiz Carlos.\n" +
"Lucas Ciminelli (Divy).\n\n" +
"Assets Usados:\n\n" +
"Unity Assets;\n\n" +
"-AxeyWorks\n" +
"- Fantasy Skybox\n" +
"- Free Food Pack\n" +
"- Haruko\n" +
"- Lv1 Monster Pack\n" +
"-Low - Poly Weapons\n\n" +
"Sons / Letras\n\n" +
"- opengameart.org\n" +
"- dafont.com\n" +
"- freesound.org\n";
        faseText.text = "Para Escolher a proxima fase clique no botão acima e assista a propaganda!";
        idiomaText.text = "Idioma";
        veraoText.text = "VERÃO";
        outonoText.text = "OUTONO";
        invernoText.text = "INVERNO";
        doceText.text = "DOCE";
        if (idioma == 0)
        {
            recodText.text = "Maior      Pontuação                " + PlayerPrefs.GetInt("record").ToString();
            recodActualText.text = "Última   Pontuação                  " + PlayerPrefs.GetInt("recordActual").ToString();
            MenuText.text = "Um Jogo Simples";
            HistText.text = "A bruxa malvada capturou a princesa Red e com tédio e descrença de que a princesa um dia sequer poderia lhe oferecer algum problema, ela lhe ofereceu participar de um jogo simples." +
    "Em uma área extra planar Red precisa pegar os pontos(Comidas)e sobreviver as armadilhas e inimigos para conseguir se libertar.\n\n" +
    "Pegue as comidas, fuja ou pule na cabeça dos inimigos.\n\n" +
    "Pegue os PowerUps e tente conseguir o máximo de pontos que puder, e assim talvez a princesa Red consiga se libertar deste jogo.\n\n" +
    "\n Obs: \n\n" +
    "Cuidado com o espirito branco, você vai perder se tocar nele.";
            obsText.text = "Agradecimentos:\n\n" +
    "Lara Bueno.\n" +
    "Vivian Lino.\n" +
    "Marcos Paulo.\n" +
    "Luiz Carlos.\n" +
    "Lucas Ciminelli (Divy).\n\n" +
    "Assets Usados:\n\n" +
    "Unity Assets;\n\n" +
    "- AxeyWorks\n" +
    "- Fantasy Skybox\n" +
    "- Free Food Pack\n" +
    "- Haruko\n" +
    "- Lv1 Monster Pack\n" +
    "-Low Poly Weapons\n\n" +
    "Sons / Letras\n\n" +
    "- opengameart.org\n" +
    "- dafont.com\n" +
    "- freesound.org\n";
            faseText.text = "Para Escolher a proxima fase clique no botão acima e assista a propaganda!";
            idiomaText.text = "Idioma";
            veraoText.text = "VERÃO";
            outonoText.text = "OUTONO";
            invernoText.text = "INVERNO";
            doceText.text = "DOCE";
        }
        if (idioma == 1)
        {
            recodText.text = "Highest      Score                " + PlayerPrefs.GetInt("record").ToString();
            recodActualText.text = "Last           Score            " + PlayerPrefs.GetInt("recordActual").ToString();
            MenuText.text = "Simple Game";
            HistText.text = "The evil witch captured Princess Red, and with boredom and disbelief that the princess might one day offer him some trouble, she offered to participate in a simple game." +
 "In an extra planar area, Red needs to collect the points (Food) and survive the traps and enemies to be able to break free.\n\n" +
 "Take the food, run away or jump on enemies' heads.\n\n" +
 "Get the PowerUps and try to get as many points as you can, so maybe Princess Red can break free of this game.\n\n" +
 "\n Note: \n\n" +
 "Watch out for the white spirit, if you touch it you will lose!";
            obsText.text = "Thanks:\n\n" +
    "Lara Bueno.\n" +
    "Vivian Lino.\n" +
    "Marcos Paulo.\n" +
    "Luiz Carlos.\n" +
    "Lucas Ciminelli (Divy).\n\n" +
    "Assets Usados:\n\n" +
    "Unity Assets;\n\n" +
    "- AxeyWorks\n" +
    "- Fantasy Skybox\n" +
    "- Free Food Pack\n" +
    "- Haruko\n" +
    "- Lv1 Monster Pack\n" +
    "- Low Poly Weapons\n\n" +
    "Sounds / letters\n\n" +
    "- opengameart.org\n" +
    "- dafont.com\n" +
    "- freesound.org\n";
            faseText.text = "To choose the next Weather click the button above and watch the advertisement!";
            idiomaText.text = "Language";
            veraoText.text = "SUMMER";
            outonoText.text = "AUTUMN";
            invernoText.text = "WINTER";
            doceText.text = "CANDY";
        }
    }

    public void PlayGame()
    {
        eventAudio.PlayOneShot(click);
        SceneManager.LoadScene("save");

    }

    public void Visibility()
    {
        eventAudio.PlayOneShot(click);
        if (scrollRect.transform.localPosition.x == 0)
        {

            //if (menu1 == false && menu2 == false && menu3 == false)
            //{ 
            //    menu1 = true;
            scrollRect.transform.localPosition = new Vector2(10000, scrollRect.transform.localPosition.y);
            //}
        }
        else
        {
            //menu1 = false;
            scrollRect.transform.localPosition = new Vector2(0, scrollRect.transform.localPosition.y);
        }
    }
    public void Visibility2()
    {
        eventAudio.PlayOneShot(click);
        if (scrollRect2.transform.localPosition.x == 0)
        {
            //if (menu1 == false && menu2 == false && menu3 == false)
            //{
            //    menu1 = true;
            scrollRect2.transform.localPosition = new Vector2(10000, scrollRect2.transform.localPosition.y);
            //}
        }
        else
        {
            //menu1 = false;
            scrollRect2.transform.localPosition = new Vector2(0, scrollRect2.transform.localPosition.y);
        }
    }
    public void Visibility3()
    {
        eventAudio.PlayOneShot(click);
        if (scrollRect3.transform.localPosition.x == 0)
        {
            //if (menu1 == false && menu2 == false && menu3 == false)
            //{
            //    menu1 = true;
            scrollRect3.transform.localPosition = new Vector2(10000, scrollRect3.transform.localPosition.y);
            //}
        }
        else
        {
            //menu1 = false;
            scrollRect3.transform.localPosition = new Vector2(0, scrollRect3.transform.localPosition.y);
        }
    }

    //public void onRewardedVideoLoaded()
    //{
    //    //throw new NotImplementedException();
    //}

    //public void onRewardedVideoFailedToLoad()
    //{
    //    //throw new NotImplementedException();
    //}

    //public void onRewardedVideoShown()
    //{
    //    //throw new NotImplementedException();
    //}

    //public void onRewardedVideoFinished(int amount, string name)
    //{
    //    PlayerPrefs.SetInt("maisVida", 1);
    //    PlayerPrefs.SetInt("monetiza", 0);
    //    //throw new NotImplementedException();
    //}

    //public void onRewardedVideoClosed()
    //{
    //    PlayerPrefs.SetInt("maisVida", 0);
    //    PlayerPrefs.SetInt("monetiza", 0);
    //    //throw new NotImplementedException();
    //}

    public void MudarSom()
    {
        eventAudio.volume = som.value;
        PlayerPrefs.SetFloat("som", som.value);
        PlayerPrefs.SetInt("modifica", 1);
    }

    public void MudarMovimento()
    {
        PlayerPrefs.SetFloat("giro", move.value);
        PlayerPrefs.SetInt("modifica", 1);
    }



    public void onSkippableVideoLoaded()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        //throw new NotImplementedException();
    }

    public void onSkippableVideoFailedToLoad()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        //throw new NotImplementedException();
    }

    public void onSkippableVideoShown()
    {
        PlayerPrefs.SetInt("monetiza", 0);
        //throw new NotImplementedException();
    }

    public void onSkippableVideoFinished()
    {
        PlayerPrefs.SetInt("maisVida", 1);
        PlayerPrefs.SetInt("monetiza", 0);
        //throw new NotImplementedException();
    }

    public void onSkippableVideoClosed()
    {

        //throw new NotImplementedException();
    }


    public void Verao()
    {
        eventAudio.PlayOneShot(click);
        PlayerPrefs.SetInt("fase", 0);
        madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
        madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele
        pantaArvore.color = Color.HSVToRGB(0.4f, 0.5f, 0.5f);//verde arvore
        pantas.color = Color.HSVToRGB(0.4f, 0.7f, 0.7f);//verde claro
        chao.color = Color.HSVToRGB(0.4f, 0.6f, 0.6f);//verde claro chao
        flor1.color = Color.HSVToRGB(0.0f, 0.42f, 0.6f);//marrom desbotado
        musgo.color = Color.HSVToRGB(0.4f, 0.8f, 0.8f);//verde muito claro
        cogumelo1.color = Color.HSVToRGB(0.16f, 0.40f, 1.0f);//amarelo desbotado
        pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza

    }
    public void Outono()
    {
        PlayerPrefs.SetInt("fase", 1);
        eventAudio.PlayOneShot(click);
        madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        pantaArvore.color = Color.HSVToRGB(0.0f, 1.0f, 0.2f);//vermelho escuro
        pantas.color = Color.HSVToRGB(0.088f, 0.85f, 0.8f);//laranja
        chao.color = Color.HSVToRGB(0.16f, 0.86f, 0.6f);//amarelo escuro
        flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
        musgo.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
        cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 0.9f);//amarelo
        pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
    }
    public void Inverno()
    {
        PlayerPrefs.SetInt("fase", 2);
        eventAudio.PlayOneShot(click);
        madeiraTerra.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        madeira2.color = Color.HSVToRGB(0.1f, 0.52f, 0.2f);//marrom escuro
        pantaArvore.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        pantas.color = Color.HSVToRGB(0.1f, 0.25f, 0.95f);//cor de pele muito claro
        chao.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
        flor1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        musgo.color = Color.HSVToRGB(0.0f, 0.0f, 0.7f);//"branco"
        cogumelo1.color = Color.HSVToRGB(0.1f, 0.52f, 0.68f);//cor de pele claro
        pedra.color = Color.HSVToRGB(0.0f, 0.0f, 0.3f);//cinza
    }
    public void Doce()
    {
        PlayerPrefs.SetInt("fase", 3);
        eventAudio.PlayOneShot(click);
        madeiraTerra.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
        madeira2.color = Color.HSVToRGB(0.0f, 0.0f, 0.92f);//"branco"
        pantaArvore.color = Color.HSVToRGB(0.84f, 0.60f, 0.99f);//rosa
        pantas.color = Color.HSVToRGB(0.5f, 0.84f, 0.82f);//azul calro
        chao.color = Color.HSVToRGB(0.6f, 1.0f, 0.7f);//azul escuro
        flor1.color = Color.HSVToRGB(0.0f, 1.0f, 0.7f);//vermelho
        musgo.color = Color.HSVToRGB(0.7f, 0.5f, 0.5f);//roxo
        cogumelo1.color = Color.HSVToRGB(0.16f, 0.84f, 1.0f);//amarelo
        pedra.color = Color.HSVToRGB(0.0f, 0.89f, 0.29f);//chocolate
    }



    //public void ShowRewardedAd()
    //{
    //    if (Advertisement.IsReady("rewardedVideo"))
    //    {
    //    PlayerPrefs.SetInt("monetiza", 0);
    //    monetiza = 0;
    //        var options = new ShowOptions { resultCallback = HandleShowResult };
    //        Advertisement.Show("video", options);
    //    }
    //}

    //private void HandleShowResult(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //        //Debug.Log("The ad was successfully shown.");
    //        PlayerPrefs.SetInt("maisVida", 1);
    //        // YOUR CODE TO REWARD THE GAMER
    //        // Give coins etc.
    //        break;
    //        case ShowResult.Skipped:
    //        //Debug.Log("The ad was skipped before reaching the end.");
    //        PlayerPrefs.SetInt("maisVida", 0);
    //        break;
    //        case ShowResult.Failed:
    //        //Debug.LogError("The ad failed to be shown.");
    //        PlayerPrefs.SetInt("maisVida", 0);
    //        break;
    //    }
    //}
}

