using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float       _mouseSpeed = 2.5f;
    private float       _rotationAngle;
    private Vector3     _rotationDetector;


    public float        cameraRotation;

    public float turningSideChecker;

    /*FROM PLAY STARTING POSITION
    1 = FRONT
    2 = RIGHT
    3 = BACK
    4 = LEFT
    */

    public int cameraPosition;

    private void Start()
    {
        cameraPosition = 1;
        cameraRotation = 1;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        _rotationDetector = transform.localEulerAngles;

        if (Input.GetMouseButton(1))
        {
            _rotationDetector.y += Input.GetAxis("Mouse X") * _mouseSpeed;
            cameraRotation = Input.GetAxis("Mouse X");
            turningSideChecker += Input.GetAxis("Mouse X");

            Cursor.lockState = CursorLockMode.Locked;
            GetCameraPosition();
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.localEulerAngles = _rotationDetector;
    }

    private void GetCameraPosition()
    {
        if(_rotationDetector.y < 45.0 && _rotationDetector.y >= -45.0)
        {
            cameraPosition = 1;
        }
        if (_rotationDetector.y < -45.0 && _rotationDetector.y > - 135.0)
        {
            cameraPosition = 2;
        }
        if (_rotationDetector.y < 225.0 && _rotationDetector.y >= 135.0)
        {
            cameraPosition = 3;
        }
        if (_rotationDetector.y > 45.0 && _rotationDetector.y < 135.0)
        {
            cameraPosition = 4;
        }

    }

}
