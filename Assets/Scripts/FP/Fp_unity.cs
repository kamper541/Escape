using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Optional;
using Optional.Linq; // Linq query syntax support
using Optional.Unsafe; // Unsafe value retrieval

public class Fp_unity : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        string str = "abc";
        var None = str.SomeWhen(s => s == "cba"); // Return None if predicate is violated
        print(None);
        None = str.NoneWhen(s => s == "abc");
        print(None);
    }
    void Start()
    {
        string str = "abc";
        var None = str.SomeWhen(s => s == "cba"); // Return None if predicate is violated
        print(None);
        None = str.NoneWhen(s => s == "abc");
        print(None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
