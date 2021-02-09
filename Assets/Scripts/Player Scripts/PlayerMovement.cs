using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public  int framePerU;

    private static float step;


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
        // if(MenuScript.closing){
        //     RunBlock.setRunning();
        //     RunBlock.setRotating();
        //     RunBlock.setActivate();
        // }
        // if(this.transform.position.y < -5f){
        //     RunBlock.setRunning();
        //     RunBlock.setRotating();
        //     RunBlock.setActivate();
        //     SceneManager.LoadScene("GameOver");
        // }
        }

    void FixedUpdate() {
        // rb.constraints = RigidbodyConstraints.FreezeRotation;
        // if(RunBlock.getRotating() == true){
        // RotatePlayer(RunBlock.getRevs());
        // }
        // else if(RunBlock.getRunning() == true){
        // MovePlayer(RunBlock.getSteps());
        // }
        if(Listener.get_to_move() == true){
            print("move");
            MovePlayer(Listener.get_steps());
        }
        else if(Listener.get_to_turn() == true){
            print("turn");
            RotatePlayer(Listener.get_degree());
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

    public void RotatePlayer(float ans){
        transform.Rotate(0 , this.transform.rotation.y + ans , 0);
        Listener.toggle_to_turn();
        Debug.Log(angle);
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
