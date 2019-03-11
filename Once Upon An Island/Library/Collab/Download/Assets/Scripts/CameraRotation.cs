using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const float _mouseSpeed = 2.5f;
    public float       _cameraRotation;
    private float       _turningSideChecker;
    private Vector3     _cameraRotationVector;

    public int          turnSideGetter;

    private void Start()
    {
        _cameraRotation = 0;
        _turningSideChecker = 0;
        turnSideGetter = 0;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        _cameraRotationVector = transform.localEulerAngles;

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cameraRotation = Input.GetAxis("Mouse X");
            _cameraRotationVector.y += Input.GetAxis("Mouse X") * _mouseSpeed;         
            //GET ROTATION BY INPUT
            GetCameraRotation();
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.localEulerAngles = _cameraRotationVector;
    }

    //GET ROTATION BY INPUT
    private void GetCameraRotation()
    {
        _turningSideChecker     += Input.GetAxis("Mouse X");

        if (_cameraRotation > 0 && _turningSideChecker > 18)
        {
            _turningSideChecker = -18;
            turnSideGetter = 1;

        }
        else if (_cameraRotation < 0 && _turningSideChecker < -18)
        {
            _turningSideChecker = 18;
            turnSideGetter = -1;
        }
        Debug.Log(turnSideGetter);
    }

    //GET ROTATION BY TRIGGERS
    /*private void OnTriggerEnter(Collider other)
    {
        if (_cameraRotation > 0)
        {
            turnSideGetter = 1;
        }
        else if (_cameraRotation < 0)
        {
            turnSideGetter = -1;
        }
        Debug.Log(turnSideGetter);
    }
    */
     
}
