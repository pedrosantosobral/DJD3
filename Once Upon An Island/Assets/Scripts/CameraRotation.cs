using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const float _mouseSpeed = 2.5f;
    public Vector3     cameraRotationVector;

    public float        cameraExactPosition;
    public int          cameraPosition;
    public int          turnSideGetter;

    private void Start()
    {
        turnSideGetter = 0;
        cameraPosition = 1;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        cameraRotationVector = transform.localEulerAngles;

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            cameraRotationVector.y += Input.GetAxis("Mouse X") * _mouseSpeed;         
            GetCameraRotation_ByAngles();

        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.localEulerAngles = cameraRotationVector;
    }

    private void GetCameraRotation_ByAngles()
    {
        if ((cameraRotationVector.y < 44.0 && cameraRotationVector.y > 1) ||
         (cameraRotationVector.y < 359.0) && (cameraRotationVector.y > 316.0))
        {
            cameraPosition = 1;
        }
        if (cameraRotationVector.y > 46.0 && cameraRotationVector.y < 134.0)
        {
            cameraPosition = 2;
        }
        if (cameraRotationVector.y > 136.0 && cameraRotationVector.y < 224.0)
        {
            cameraPosition = 3;
        }
        if (cameraRotationVector.y > 226.0 && cameraRotationVector.y < 314.0)
        {
            cameraPosition = 4;
        }
    } 
}
