using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim;

    void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            // anim.Play("CloseDoors");
            Invoke("To_Next_Stage",1.0f);
        }
    }

    private void To_Next_Stage()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

}
