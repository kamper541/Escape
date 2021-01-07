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
    static private JToken[] To_Look; 

    static JToken[] get_command(){
        return To_Look;
    }

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
        webView.OnMessageReceived += (view, message) => {
            JObject o = JObject.Parse(message.Path);
                // ReadFunc(o);
            JArray items = (JArray)o["payload"];
            int l = items.Count;
            print(l);
                // print(o["payload"][0].Type);
                // JObject j = JObject.Parse((string)o["payload"][0]);
                // print(j["body"]);
                
                print(message.Path);
                return;
        };
        webView = null;
        
    }

    void ReadFunc(JObject o) {
        // print(o);
        // print(o["body"].Type);
        // print(o["body"]);
        int i = 0;
        JToken To_send = o["payload"];
        int length = FindLength(To_send);
        print(length);
        // To_Look = inside(To_send,length);
        i = 0;
        while(i < length){
            // print(ans[i]);
            // print(To_Look[i]);
            i++;
        }
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

    JToken[] inside(JToken aa, int len){
        JToken save = aa;
        JToken[] ans = new JToken[len];
        int i = 0;
        while(save != null){
            ans[i] = save;
            save = save.Next;
            i++;
        }

        return ans;
    }

}
