using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

public class LevelLoader : MonoBehaviour
{
    public bool openDoor = true;

    public int Scene_now = 0;

    public LoadBar loadBar;

    private Animation anim;

    public static bool do_it;

    private GameObject UIe;

    public static bool closing;

    public static bool PlayAnim;



    void Start()
    {
      anim = this.GetComponent<Animation>();
      do_it = false;
      closing = false;
      PlayAnim = false;
      // When scene starts check if doors has to be opened and play door open animation.
      if(openDoor)
      {
        anim.Play("OpenDoors");
        openDoor = false;
      }
    }

    void Update(){
      if(do_it)
      {
        To_Next_Stage();
      }
    }

    // Used to load next level.
    public void LoadLevel(int sceneIndex)
    {
      // Play close door animation.
      try{
        print("try");
        close_the_f();
        Invoke("Set_Inactive",0.5f);
        Invoke("Play_Anim",0.5f);
        Scene_now = sceneIndex;
        Invoke("Load_Now",1.0f);
      }catch(Exception e){
        print("catch");
        close_the_f();
        Invoke("Play_Anim",0.5f);
        Scene_now = sceneIndex;
        Invoke("Load_Now",1.0f);
      }
      // Load scene async.
      // StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    public void Load_Now(){
      SceneManager.LoadScene (Scene_now);
    }

    
    // private void OnTriggerEnter(Collider other) 
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         anim.Play("CloseDoors");
    //         Invoke("To_Next_Stage",1.0f);
    //     }
    // }

    private void To_Next_Stage()
    {
        do_it = false;
        close_the_f();
        Invoke("Set_Inactive",0.5f);
        Invoke("Play_Anim",0.5f);
        Invoke("Go_to_next",1.0f);
    }

    private void Set_Inactive()
    {
      try{
      UIe = GameObject.FindGameObjectWithTag("UI");
      UIe.SetActive(false);
      }catch{
        return;
      }
    }

    private void Play_Anim(){
      anim.Play("CloseDoors");
    }

    public void close_the_f(){
      print("closing");
      closing = true;
    }

    void Go_to_next()
    {
      PlayerPrefs.SetInt("ReachedLevel", PlayerPrefs.GetInt("ReachedLevel") + 1);
      SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    // public void LoadLevel_Next()
    // {
      
    // }

    // IEnumerator LoadLevelAsync(int sceneIndex)
    // {
    //   // Delay for door close animation.
    //   yield return new WaitForSeconds(0.5f);

    //   // Loading scene async and getting loading progress.
    //   AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    //   // While loading isn't done.
    //   while(!operation.isDone)
    //   {
    //     // Get loading progress.
    //     float progress = Mathf.Clamp01(operation.progress / 0.9f);
    //     // Load progress to the loadbar.
    //     loadBar.progress = 1 - progress;
    //     yield return null;
    //     // Save loadbar rotation for the next scene.
    //     loadBar.saveRotation();
    //   }
    // }
}
