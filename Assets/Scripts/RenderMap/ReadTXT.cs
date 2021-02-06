using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTXT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 1;
        TextAsset asset = Resources.Load("stage" + a.ToString()) as TextAsset;
        print(asset.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
