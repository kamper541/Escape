using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

public class Enermy_Triggered : MonoBehaviour
{
    private GameObject[] UIe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player"))
        {
            // UIe = GameObject.FindGameObjectsWithTag("UI Canvas");
        }
    }
}
