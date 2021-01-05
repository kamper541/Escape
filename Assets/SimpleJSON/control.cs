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

    static bool a = false;
    // JObject ans = null;

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
        // webView.OnMessageReceived += (view, message) => {
        //     // if(!a){
        //     //     // JSONNode node = JSON.Parse(message.Path);
        //     //     // string score = node["body"].Value;
        //     //     // print(score);
        //     //     JObject o = JObject.Parse(message.Path);
        //     //     print((string)o["body"][0]["type"]);
        //     //     print(message.Path);
        //     //     print(JsonUtility.ToJson(message.Path));
        //     //     a = true;
        //     // }
        //     // print(message.RawMessage);
        //     // if(message && !a){
        //     //     JObject o = JObject.Parse(message.Path);
        //     //     print((string)o["body"][0]["type"]);
        //     //     print(message.Path);
        //     //     print(JsonUtility.ToJson(message.Path));
        //     //     a = true;   
        //     // }else{
        //     //     a = false;
        //     // }
        //     if(ans == null){
        //         JObject o = JObject.Parse(message.Path);
        //         ans = JObject.Parse(message.Path);
        //         print((string)o["body"][0]["type"]);
        //         print(message.Path);
        //         a = true;
        //     }else{

        //     }
        // };  
    }

    void FixedUpdate() {
        webView.OnMessageReceived += (view, message) => {
            JObject o = JObject.Parse(message.Path);
                // ans = JObject.Parse(message.Path);
                ReadFunc(o);
                print(message.Path);
                return;
        };
        webView = null;
        
    }

    void ReadFunc(JObject o) {
        print((string)o["body"][0]["type"]);
        print(o["body"].First);
        print(o["body"].Type);
        int i = 0;
        // while (o["body"][i] != null){
        //     i++;
        // }
        JToken To_send = o["body"].First;
        int length = FindLength(To_send);
        print(length);
        string[] ans = new string[length];
        while(i < length){
            ans[i] = (string)o["body"][i]["type"];
            i++;
        }
        i = 0;
        while(i < length){
            print(ans[i]);
            i++;
        }

        // string[] ans = new string[(string)o["body"].Length];
        // int count = 0;
        // while((string)o["body"].Length > count){
        //     ans[count] = (string)o["body"][i]["type"];
        // }
        // print(ans);
    }

    int FindLength(JToken p){
        int i = 0;
        JToken save = p;
        while(save != null){
            save = save.Next;
            i++;
        }
        return i;
    }
}
