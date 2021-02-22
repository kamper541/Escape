using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

public class Wait_Dead : MonoBehaviour
{

    public static bool dead_or_not;

    public GameObject UIe;

    public Canvas To_Set;

    // Start is called before the first frame update
    void Start()
    {
        dead_or_not = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead_or_not && !Wait_Win.win_or_not)
        {
            try{
                LevelLoader.close_web();
                UIe.SetActive(true);
            }catch(Exception error){
                print(error);
            }
        }
    }
}
