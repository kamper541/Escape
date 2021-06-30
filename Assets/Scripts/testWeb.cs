using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testWeb : MonoBehaviour
{

    UniWebView webView;

    [SerializeField]
    RectTransform myUITransfrom;
    // Start is called before the first frame update
    void Start()
    {
        var webviewGameObject = new GameObject("UniWebView");
        webView = webviewGameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0 , 0 , Screen.width , Screen.height);
        webView.ReferenceRectTransform = myUITransfrom;

        try{ 
        var indexURL = UniWebViewHelper.StreamingAssetURLForPath("webPage/public/index.html");
        //webView.Load(indexURL, false, accessURL);
        webView.Load(indexURL);
        webView.Show();
        }catch(Exception e){
            print(e);
        }
        // webView.Load("https://www.google.com");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
