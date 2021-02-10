using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim;
    public bool openDoor = true;

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
            // anim.Play("CloseDoors");
            Invoke("To_Next_Stage",2.0f);
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
