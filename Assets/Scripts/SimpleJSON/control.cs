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
    static private JObject Inside_Payload = new JObject(); 

    //-----Get, Set------

    private static void Set_Payload(JObject o){
        Inside_Payload = o;
        Set_Begin();
    }

    public static JObject Get_Payload(){
        return Inside_Payload;
    }

    private static void Set_Begin(){
        Begin = true;
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
        webView.OnMessageReceived += (view, message) => {
            try {
            //     JObject o = JObject.Parse(message.Path);
            // }catch (Exception e){
            //     print(e);
            // }
            JObject o = JObject.Parse(message.Path);
            // JArray items = (JArray)o["payload"];
            // int l = items.Count;
            // print(l);
            // if( l > 1 ){
            //     print("Block is not detatch");
            //     return ;
            // }
            // else if( l == 0 ){
            //     print("Choose some block!!");
            //     return ;
            // }
            // else if( l == 1 ){
            //     Set_Payload(o);
            // }
            // var test = o;
                JEnumerable<JToken> jt = o["payload"].Children();
                // IList<JToken> test = o.ChildrenTokens;
                foreach(JToken token in jt ){
                    print(token);
                }
                print(jt);
            }catch (Exception e){
                print(e);
            }
            // var test1 = o.SelectToken("name");
            // print((string)o);
            // print((string)test1);
        };
        webView = null;
        
    }

    // void ReadFunc(JObject o) {
    //     // print(o);
    //     // print(o["body"].Type);
    //     // print(o["body"]);
    //     int i = 0;
    //     JToken head = o["payload"];
    //     int length = FindLength(head);
    //     if(length > 1){
    //         print("Block is not detatch.");
    //         return ;
    //     }
    //     if(length == 0){
    //         print("Choose some block");
    //         return ;
    //     }
    //     if(length == 1){
    //         print(length);
    //         Inside_Payload = inside(head,length);
    //         i = 0;
    //         while(i < length){
    //         // print(ans[i]);
    //         // print(To_Look[i]);
    //         i++;
    //         }
    //     }
    // }

    // int FindLength(JToken p){
    //     int i = 0;
    //     JToken save = p;
    //     while(save != null){
    //         save = save.Next;
    //         i++;
    //     }
    //     return i;
    // }

    // JToken[] inside(JToken aa, int len){
    //     JToken save = aa;
    //     JToken[] ans = new JToken[len];
    //     int i = 0;
    //     while(save != null){
    //         ans[i] = save;
    //         save = save.Next;
    //         i++;
    //     }

    //     return ans;
    // }

}
