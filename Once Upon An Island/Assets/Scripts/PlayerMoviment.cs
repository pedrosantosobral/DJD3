using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public CameraRotation           cameraInstance;


    //if moviment vector multiplication is removed reduce speed to 0.27
    public float                    movimentSpeed       = 27f;

    //Probably have to had min and max variables to all the inputs and add a clamp
    private const float             _jumpAccelaration   = 500.0f;
    private const float             _gravityAcelaration = 20.0f;
    private const float             _maxJumpVelocity    = 500.0f;
    private const float             _maxFallVelocity    = 30.0f;

    private int                   _cameraReference;

    private CharacterController     _player;
    private Vector3                 _guideVector;
    private Vector3                 _movimentVector;
    //test
    private Vector3 _jumpVelocity;

    void Start()
    {
        _player             = GetComponent<CharacterController>();
        //test
        _jumpVelocity       = Vector3.zero;
        //LINE TO COPY
        _cameraReference = 1;
    }

    void Update()
    {
        UpdateMoviment();
        UpdatePlayerMovimentItself();
    }

    private void UpdateMoviment()
    {

        if (cameraInstance.turnSideGetter < 0)
        {
            _player.transform.Rotate(0, -90, 0);
            cameraInstance.turnSideGetter = 0;
        }
        else if (cameraInstance.turnSideGetter > 0)
        {
            _player.transform.Rotate(0, 90, 0);
            cameraInstance.turnSideGetter = 0;
        }

        _movimentVector.x = Input.GetAxis("Horizontal") * movimentSpeed;
        _movimentVector.z = Input.GetAxis("Vertical") * movimentSpeed;

        //jump need fix
        if (_player.isGrounded)
        {
            _jumpVelocity.y = Input.GetButtonDown("Jump") ? _jumpAccelaration : 0f;
        }

        else
        {
            _jumpVelocity.y = -_gravityAcelaration;
        }


        // TODO FIX JUMP
        _movimentVector.y += _jumpVelocity.y * Time.deltaTime;
        _movimentVector.y = _jumpVelocity.y == 0f ? -0.1f : Mathf.Clamp(_jumpVelocity.y, -_maxFallVelocity, _maxJumpVelocity);
    }

    private void UpdatePlayerMovimentItself()
    {
        //TEST
        Vector3 motion = _movimentVector * Time.deltaTime;
        _player.Move(transform.TransformVector(motion));

    }
}
