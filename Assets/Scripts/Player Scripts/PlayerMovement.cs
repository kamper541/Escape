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

    float zPost;

    float angle;

    int framePerU;

    public static bool getFinish(){
        return finish;
    }

    private void Start() {
        this.transform.position = new Vector3(0 , 5 ,0);
        this.transform.rotation = new Quaternion(0 , 0 , 0 ,0);
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
        if(Listener.check == true){
            MovePlayer(1);
        }
    }
    void GetInput(){
        // if(Input.GetMouseButtonDown(0)){
        //     canMove = true;
        //     finish = false;
        // }else if (Input.GetMouseButtonUp(0)){
        //     canMove = false;
        //     finish = true;
        // }
    }
    void UpdateForward(){
        transform.forward = Vector3.Slerp(
            transform.forward, targetForward, Time.deltaTime * smoothMovement
        );
    }
    public void MovePlayer(float ans){
        Debug.Log("Moving Player" + ans);
            if(framePerU == 135){
                // RunBlock.setRunning();
                zPost = this.transform.localPosition.z;
                framePerU = 0;
            }else{
             transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
             framePerU++;
            }
    }


    public void RotatePlayer(float ans){

        //Debug.Log("Rotating");
        
        // if(this.transform.rotation.eulerAngles.y >= angle + 90){
        //     RunBlock.setRotating();
        //     angle = this.transform.rotation.eulerAngles.y;
        // }else{
        // // float tar = this.transform.rotation.y + ans;
        // // Quaternion target = Quaternion.Euler(0.0f, tar, 0.0f);
        // // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target,  Time.deltaTime * 5.0f);
        // // yield return new WaitForSeconds(2f);
        // transform.Rotate(0 , 90 , 0);
        // }
        transform.Rotate(0 , this.transform.rotation.y + 90 , 0);
        // RunBlock.setRotating();
        Debug.Log(angle);
    }

}
