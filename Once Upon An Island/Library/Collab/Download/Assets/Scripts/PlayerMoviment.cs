using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public CameraRotation           cameraInstance;

    public float                    movimentSpeed       = 25f;

    public int                      turnCamera = 0;

    private const float             _jumpAccelaration   = 400.0f;
    private const float             _gravityAcelaration = 20.0f;
    private const float             _maxJumpVelocity    = 600.0f;
    private const float             _maxFallVelocity    = 30.0f;

    private CharacterController     _player;
    private Vector3                 _guideVector;
    private Vector3                 _movimentVector;
    private Vector3                 _jumpVelocity;

    void Start()
    {
        _player             = GetComponent<CharacterController>();

        _jumpVelocity       = Vector3.zero;
    }

    void Update()
    {
        UpdateMoviment();
        UpdatePlayerMovimentItself();
        ResetRotations();
    }

    private void UpdateMoviment()
    {
     
        if(cameraInstance.turnSideGetter < 0)
        {
            _player.transform.Rotate(0, -90, 0);

        }
        else if (cameraInstance.turnSideGetter > 0)
        {
            _player.transform.Rotate(0, 90, 0);
        }

        _movimentVector.x = Input.GetAxis("Horizontal") * movimentSpeed;
        _movimentVector.z = Input.GetAxis("Vertical") * movimentSpeed;

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

    private void ResetRotations()
    {
        cameraInstance.turnSideGetter = 0;
    }


}
