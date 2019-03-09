using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const float _mouseSpeed = 2.5f;
    private float       _cameraRotation;
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
            _cameraRotationVector.y += Input.GetAxis("Mouse X") * _mouseSpeed;
            GetCameraRotation();
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.localEulerAngles = _cameraRotationVector;
    }

    private void GetCameraRotation()
    {
        _turningSideChecker     += Input.GetAxis("Mouse X");
        _cameraRotation          = Input.GetAxis("Mouse X");

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
    }
}
