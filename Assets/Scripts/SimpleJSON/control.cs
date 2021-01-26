using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class control : MonoBehaviour
{
    // Start is called before the first frame update
    UniWebView webView;

    [SerializeField]
    RectTransform myUITransfrom;

    static bool Begin = false;
    static private JEnumerable<JToken> Inside_Payload = new JEnumerable<JToken>();

    //-----Get, Set------

    public static JEnumerable<JToken> Get_JToken(){
        return Inside_Payload;
    }

    public static void Set_Begin(){
        Begin = false;
    }

    public static bool Get_Begin(){
        return Begin;
    }

    //-----Start Here-----

    void Start()
    {
        var webviewGameObject = new GameObject("UniWebView");
        // var uuu = UniWebViewHelper.StreamingAssetURLForPath("index.html");
        // url = Path.Combine(Application.streamingAssetsPath, "SampleVideo_1280x720_5mb.mp4");
        // Debug.Log(Application.streamingAssetsPath);
        webView = webviewGameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0 , 0 , Screen.width , Screen.height);
        webView.ReferenceRectTransform = myUITransfrom;
        // webView.Load("https://www.google.com");
        webView.Load("https://edo-controller.web.app");
        // webView.Load("localhost:5000");
        webView.CleanCache();
        UniWebView.ClearCookies();
        webView.AddUrlScheme("code");
        webView.Show();
        webView.OnPageFinished += (view , statusCode , url) => {
            // return true;
        };
        webView.OnShouldClose += (view) => {
            webView = null;
            return true;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate() {
        if(webView == null){
            return;
        }
        webView.OnMessageReceived += (view, message) => {
            JObject o = JObject.Parse(message.Path);
            JEnumerable<JToken> jt = o["payload"].Children();
            Inside_Payload = jt;
            Begin = true;
        };
        Begin = false;
        webView = null;
    }

    

}
