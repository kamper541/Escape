using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public float moveSmoothing = 10f;
    public float rotationSmoothing = 15f;

    private Vector2 touchPosition;
    private float swipeResistance = 200.0f;

    private Transform target ;
    private Vector3 targetForward;

    private Vector3 offset;

    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 18;

    // [SerializeField] private Camera cam;
    // [SerializeField] private Transform targets;
    // [SerializeField] private float distanceToTarget = 10;

    [SerializeField]
    private GameObject KingCam;
    [SerializeField]
    private GameObject MainCam;
    private Vector3 previousPosition;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    // public FixedTouchField TouchField;

    public CharacterController controller;
	public Transform cam;
	public float speed = 6f;
	public float turnSnoothTime = 0.1f;
	float turnSnoothVelocity;
    void Awake() {
        // target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start(){
        targetForward = transform.forward;
        targetForward.y = 0f;
        //Snap();
    }

    // Update is called once per frame
    void Update(){
        // if(RunBlock.getAct()){
        //     //KingCam.SetActive(true);
        //     //MainCam.SetActive(false);
        //     FollowPlayer();
        //     zoom(Input.GetAxis("Mouse ScrollWheel"));
        // }
        // else if (!RunBlock.getAct() && !Drag.dragged){
        //     pinch();
        // }else if(!RunBlock.getAct()){

        // }

    }
    void Snap(){
        if(target != null){
            transform.position = target.position;
        }
        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    void FollowPlayer(){
        if(target != null){
            transform.position = 
                Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSmoothing);
        }
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = Vector3.Slerp(forward, forward, Time.deltaTime * rotationSmoothing);
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    void pinch(){
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;
            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
