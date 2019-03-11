using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private CameraRotation           _cameraInstance;

    public float                    movimentSpeed       = 25f;

    public int                      cameraSideReference = 1;
    public bool                     controls_without_rotation       = false;
    public bool                     right_controls                  = true;

    private const float             _jumpAccelaration   = 400.0f;
    private const float             _gravityAcelaration = 20.0f;
    private const float             _maxJumpVelocity    = 600.0f;
    private const float             _maxFallVelocity    = 30.0f;

    private CharacterController     _player;
    private Vector3                 _movimentVector;
    private Vector3                 _jumpVelocity;

    void Start()
    {
        GetCameraInstance();

        _player             = GetComponent<CharacterController>();

        _jumpVelocity       = Vector3.zero;

        GetCameraSideReference();
    }

    void Update()
    {
        UpdateMoviment();
        UpdatePlayerMovimentItself();
    }

    private void UpdateMoviment()
    {
        //TODO need fix -> initial rotation on start, until fix start game with player.transform.rotation(0, -90,0) 
        if (cameraSideReference != _cameraInstance.cameraPosition
                && (_cameraInstance.cameraPosition == cameraSideReference + 1
                || _cameraInstance.cameraPosition == cameraSideReference - 3))
        {
            _player.transform.Rotate(0, 90, 0);
            GetCameraSideReference();

        }
        else if (cameraSideReference != _cameraInstance.cameraPosition
        && (_cameraInstance.cameraPosition == cameraSideReference - 1
        || _cameraInstance.cameraPosition == cameraSideReference + 3))
        {
            _player.transform.Rotate(0, -90, 0);
            GetCameraSideReference();
        }

        _movimentVector.x = Input.GetAxis("Horizontal") * movimentSpeed;
        _movimentVector.z = Input.GetAxis("Vertical") * movimentSpeed;

        //To use in objects moviment
        /*
        switch (_cameraInstance.cameraPosition)
        {
            case 1:
                _movimentVector.x = Input.GetAxis("Horizontal") * movimentSpeed;
                _movimentVector.z = Input.GetAxis("Vertical") * movimentSpeed;
                break;
            case 2:
                _movimentVector.x = Input.GetAxis("Vertical") * movimentSpeed;
                _movimentVector.z = -Input.GetAxis("Horizontal") * movimentSpeed;
                break;
            case 3:
                _movimentVector.x = -Input.GetAxis("Horizontal") * movimentSpeed;
                _movimentVector.z = -Input.GetAxis("Vertical") * movimentSpeed;
                break;
            case 4:
                _movimentVector.x = -Input.GetAxis("Vertical") * movimentSpeed;
                _movimentVector.z = Input.GetAxis("Horizontal") * movimentSpeed;
                break;
        }
        */

        if (_player.isGrounded)
        {
            _jumpVelocity.y = Input.GetButtonDown("Jump") ? _jumpAccelaration : 0f;
        }

        else
        {
            _jumpVelocity.y = -_gravityAcelaration;
        }

        // TODO FIX JUMP (TEM A VER COM O PERFORMACE DO PC)
        _movimentVector.y += _jumpVelocity.y * Time.deltaTime;
        _movimentVector.y =  _jumpVelocity.y == 0f ? -0.1f : Mathf.Clamp(_movimentVector.y, -_maxFallVelocity, _maxJumpVelocity);
    }

    private void UpdatePlayerMovimentItself()
    {
        Vector3 motion = _movimentVector * Time.deltaTime;
        _player.Move(transform.TransformVector(motion));
    }

    private void GetCameraInstance()
    {
        GameObject instance = GameObject.FindWithTag("Camera");

        if (instance != null)
        {
            _cameraInstance = instance.GetComponent<CameraRotation>();
        }
    }

    private void GetCameraSideReference()
    {
        cameraSideReference = _cameraInstance.cameraPosition;
    }
}

