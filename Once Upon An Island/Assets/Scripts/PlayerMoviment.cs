﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float movimentSpeed;
    private CharacterController player;

    private Vector3 _guideVector;
    private Vector3 _movimentVector;
    private GameObject _guide;

    void Start()
    {
        _guide = GameObject.Find("CameraRotation_guide");
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateGuide();
        UpdateMovimentVector();
        UpdatePlayerMovimentItself();
    }

    private void UpdateGuide()
    {
        _guideVector = _guide.transform.position;
        _movimentVector.x = _guideVector.x;
        _movimentVector.y = _guideVector.y;
    }

    private void UpdateMovimentVector()
    {
        _movimentVector.x =  Input.GetAxis("Horizontal") * movimentSpeed;
        _movimentVector.y = 0;
        _movimentVector.z = Input.GetAxis("Vertical") * movimentSpeed;
    }

    private void UpdatePlayerMovimentItself()
    {
        player.Move(transform.TransformVector(_movimentVector));
    }


}
