using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform lookAt;
    private Vector3 offset;

    private Vector2 touchPosition;

    private float distance = 5.0f;
    private float yOffset = 3.5f;

    void Start()
    {
        offset = new Vector3(transform.position.x - 5.0f, transform.position.y + 2.7f , transform.position.z);
        transform.rotation = lookAt.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // if(RunBlock.getAct()){
        //     transform.position = lookAt.position + offset;
        //     transform.rotation = lookAt.rotation;
        //     if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
        //         touchPosition = Input.mousePosition;
        //     }if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)){
        //         float swipeForce = touchPosition.x - Input.mousePosition.x;
        //         if(Mathf.Abs(swipeForce) > 2.0f){
        //             if(swipeForce < 0){
        //                 SlideCamera(true);
        //             }else{
        //                 SlideCamera(false);
        //             }
        //         }
        //     }
        // }
    }

    public void SlideCamera(bool left){
        if (left){
            offset = Quaternion.Euler(0 , 90 , 0) * offset;
        }else{
            offset = Quaternion.Euler(0, -90 ,0) * offset;
        }
    }
}
