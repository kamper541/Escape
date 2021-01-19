using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class Listener : MonoBehaviour
{
    JObject o = new JObject();
    public static bool check = false;

    //<--- get set

    // Start is called before the first frame update
    void Start()
    {
        print("Listening..");
    }

    // Update is called once per frame
    void Update()
    {
        if(control.Get_Begin()){
            check = true;
            o = control.Get_Payload();
        }
    }

    
}
