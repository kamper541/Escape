using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finnished = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Wait_Win.win_or_not == true) Finnish();


        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");
        if(seconds.Length == 3) seconds = "0" + seconds;

        timerText.text = minutes + ":" + seconds;
    }

    public void Finnish()
    {
        Destroy(this);
        timerText.color = Color.yellow; 
    }
}
