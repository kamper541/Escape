using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;
    private float smoothMovement = 15f;

    private Vector3 targetForward;
    private bool canMove;
    private Vector3 dPos;
    private Camera mainCam;

    private static bool finish = true;

    private float unit = 3f;

    //private float walk = 1f

    Vector3 oldEulerAngles;

    public  float xPost;

    public  float yPost;    

    public  float zPost;

    public  float yAxis;

    public  float angle;

    public  float angle_d;

    public  int framePerU;

    private static float step;

    float Current_Angle;

    private float desiredRot;

    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions

    int elapsedFrames = 0;

    float timer = 0;

    bool timerReached = false;

    private bool Turning = false;

    public  bool getFinish(){
        return finish;

    }

    private void Start() {
        this.transform.position = new Vector3(xPost , yPost ,zPost);
        this.transform.rotation = new Quaternion(0 , yAxis , 0 ,0);
        oldEulerAngles = this.transform.rotation.eulerAngles;
        zPost = this.transform.localPosition.z;
        angle = this.transform.rotation.y;
        framePerU = 0;
    }

    void Awake(){
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;

        mainCam = Camera.main;
    }


    //Update is called once per frame
        void Update()
        {
        
            if(this.transform.position.y < -5f){
                Wait_Dead.dead_or_not = true;    
            }

        }

    void FixedUpdate() {
        // rb.constraints = RigidbodyConstraints.FreezeRotation;
        // if(RunBlock.getRotating() == true){
        // RotatePlayer(RunBlock.getRevs());
        // }
        // else if(RunBlock.getRunning() == true){
        // MovePlayer(RunBlock.getSteps());
        // }
        print("Movement");
        if(Listener.get_to_move() == true){
            print("move");
            MovePlayer(Listener.get_steps());
        }
        else if(Listener.get_to_turn() == true){
            if(!Turning) 
            {
                StartCoroutine(RotateMe(Vector3.up * (Listener.get_degree()) , 1.0f));
            }
        }
        else if(Listener.get_to_jump() == true){
            print("jump");
            Jump();
        }
    }

    void UpdateForward(){
        transform.forward = Vector3.Slerp(
            transform.forward, targetForward, Time.deltaTime * smoothMovement
        );
    }

    public void MovePlayer(float ans){
        Debug.Log("Moving Player" + ans);
        if(framePerU == 20 * ans){
            Listener.toggle_to_move();
            print(Listener.get_to_move());
            zPost = this.transform.localPosition.z;
            framePerU = 0;
        }else{
            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
            framePerU++;
        }
    }


    IEnumerator RotateMe(Vector3 byAngles, float inTime) {
        Turning = true;
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        Listener.toggle_to_turn();
        Turning = false;
      }
    public void RotatePlayer(float ans){
        // transform.Rotate(0 , this.transform.rotation.y + desiredRot / 8 , 0);
        // print(this.transform.rotation.y);
        // if(framePerU == 20){
        //     Listener.toggle_to_turn();
        //     framePerU = 0;
        // }else{
        //     transform.Rotate(Vector3.up * Time.deltaTime * 5.0f);
        //     framePerU++;
        // }
    }

    public void Jump()
    {
        if(framePerU == 20.0f){
            Listener.toggle_to_jump();
            framePerU = 0;
        }else{
            transform.Translate(Vector3.up * Time.deltaTime * 9.8f);
            framePerU ++;
        }
    }

}
