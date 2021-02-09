using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class Listener : MonoBehaviour
{
    JObject o = new JObject();

    private bool Activated = false;

    private static bool to_move = false;

    private static bool to_turn = false;

    private static bool to_jump = false;

    private static float steps;

    private static float degree;

    public static float get_steps(){
        return steps;
    }

    public static float get_degree(){
        return degree;
    }

    public static bool get_to_move(){
        return to_move;
    }

    public static void toggle_to_move(){
        to_move = false;
    }

    public static bool get_to_turn(){
        return to_turn;
    }

    public static void toggle_to_turn(){
        to_turn = false;
    }

    public static bool get_to_jump(){
        return to_jump;
    }

    public static void toggle_to_jump(){
        to_jump = false;
    }

    //<--- get set

    // Start is called before the first frame update
    void Start()
    {
        // print("Listening..");
    }

    // Update is called once per frame
    void Update()
    {
        if(!Activated)
        {
            if(control.Get_Begin())
            {
                Activated = true;
                try
                {
                    JEnumerable<JToken> jt = control.Get_JToken();
                    foreach(JToken token in jt)
                    {
                        print(token);  
                    }
                    StartCoroutine(Reading_Block(jt));
                }
                catch(Exception e)
                {
                    print(e);
                }
            }
        }
        else
        {

        }
    }

    public IEnumerator Reading_Block(JEnumerable<JToken> jt_get){
        foreach(JToken token in jt_get ){
            if((string)token["name"] == "move"){
                float val = (float)token["value"];
                steps = val;
                to_move = true;
                yield return new WaitWhile(() => to_move == true);
                steps = 0;
            }
            else if((string)token["name"] == "turn"){
                float val = (float)token["value"];
                degree = val;
                to_turn = true;
                yield return new WaitWhile(() => to_turn == true);
                degree = 0;
            }
            else if((string)token["name"] == "jump"){
                to_jump = true;
                yield return new WaitWhile(() => to_jump == true);
            }
        }
        print("Activated");
        control.Set_Begin();
        Activated = false;
        control.Set_Begin();
    }

    
}
