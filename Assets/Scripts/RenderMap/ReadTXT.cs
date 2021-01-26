using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTXT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextAsset asset = Resources.Load("stage1") as TextAsset;
        print(asset.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
