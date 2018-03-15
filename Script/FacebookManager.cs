using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookManager : MonoBehaviour {

    public Text userIdText;
    public Text userPassText;

    // Use this for initialization
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else {
            FB.ActivateApp();
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback:OnLogin);
    }

    private void OnLogin(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken token = AccessToken.CurrentAccessToken;
            userIdText.text = token.UserId;
        }
        else {
            Debug.Log("Cancel login");
        }
    }
    public void Share()
    {
        FB.ShareLink(contentTitle: "Minha Maior Pontuação foi" + PlayerPrefs.GetInt("record").ToString() + "!!", 
            contentURL:new System.Uri("https://play.google.com/store/apps/details?id=com.feujogos.umjogosimples"), 
            contentDescription: "Consegue uma pontuaçao melhor que a minha?",
            callback:OnShare);
    }
    private void OnShare(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error " + result.Error);
        }
    }

}

