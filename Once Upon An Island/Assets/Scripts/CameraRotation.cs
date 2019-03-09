using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float _mouseSpeed = 2.5f;

    void Update()
    {
        RotateCamera();
    } 

    private void RotateCamera()
    {
        if(Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _mouseSpeed, 0);
            Cursor.lockState = CursorLockMode.Locked;

        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
