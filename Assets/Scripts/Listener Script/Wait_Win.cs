using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

public class Wait_Win : MonoBehaviour
{

    public static bool win_or_not;

    public GameObject UIe;

    public Canvas To_Set;

    // Start is called before the first frame update
    void Start()
    {
        win_or_not = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(win_or_not && !Wait_Dead.dead_or_not)
        {
            try{
                print(Listener.get_num_block());
                int num = PlayerPrefs.GetInt("ReachedLevel");
                PlayerPrefs.SetInt($"Level{num + 1}", Listener.get_num_block());
                LevelLoader.close_web();
                UIe.SetActive(true);
            }catch(Exception error){
                print(error);
            }
        }
    }
}
