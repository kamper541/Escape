using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjecct : MonoBehaviour
{
    public GameObject objectRotate;

	public float rotateSpeed = 50f;
	bool rotateStatus = false;

	//rotate object function
	public void RotateObject()
	{

		if (rotateStatus == false)
		{
			rotateStatus = true;
		}
		else
		{
			rotateStatus = false;
		}
	}

	void Update()
	{
		Debug.Log(Input.mousePosition.x);
		if (rotateStatus == true)
		{
			//rotate object with speed
			objectRotate.transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
		}
	}

	void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);
    }
}
