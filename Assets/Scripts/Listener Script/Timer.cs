using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text to_display;
    private float startTime;
    private bool finnished = false;
    private bool is_start = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        to_display.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        // ver2
        // if(Wait_Win.win_or_not == true) Finnish();
        // string minutes = ((int) cal_time(Time.time,startTime) / 60).ToString();
        // string seconds = (cal_time(Time.time,startTime) % 60).ToString("f1");
        // if(seconds.Length == 3) seconds = "0" + seconds;
        // timerText.text = minutes + ":" + seconds;

        // ver3
        if(Wait_Win.win_or_not == true) Finnish();
        System.Func<float,float,float> cal_time = delegate(float from,float now) {return from - now;};
        string minutes = ((int) cal_time(Time.time,startTime) / 60).ToString();
        string seconds = (cal_time(Time.time,startTime) % 60).ToString("f1");
        if(seconds.Length == 3) seconds = "0" + seconds;
        timerText.text = minutes + ":" + seconds;
        // ver1
        // if(Wait_Win.win_or_not == true) Finnish();
        // float t = Time.time - startTime;
        // string minutes = ((int) calculate_time(t) / 60).ToString();
        // string seconds = (calculate_time(t) % 60).ToString("f1");
        // if(seconds.Length == 3) seconds = "0" + seconds;
        // timerText.text = minutes + ":" + seconds;
    }

    public static float cal_time(float from, float now) => (from - now);

    public float calculate_time(float startTime){
        float x = Time.time;
        return (x - startTime);
    }

    public void Finnish()
    {
        Destroy(this);
        timerText.color = Color.yellow; 
    }
}
