using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim;
    public bool openDoor = true;
    public bool Collide = false;

    void Start()
    {
        anim = this.GetComponent<Animation>();

        if(openDoor)
        {
            // anim.Play("OpenDoors");
            // openDoor = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            SendMessage("Finnish");
            // anim.Play("CloseDoors");
            print("Hit");
            Collide = true;
            Invoke("Check_Collide",2.0f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            print("Not Hit");
            Collide = false;
        }
    }

    private void Check_Collide(){
        if(Collide){
            Invoke("To_Next_Stage",1.0f);
        }else{
            print("Cheat!!!!");
        }
    }


    // private void To_Next_Stage()
    // {

    //     PlayerPrefs.SetInt("ReachedLevel", PlayerPrefs.GetInt("ReachedLevel") + 1);
    //     SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    // }

    private void To_Next_Stage()
    {
        LevelLoader.do_it = true; 
    }

}
