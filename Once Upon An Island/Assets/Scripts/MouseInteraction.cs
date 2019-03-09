using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    private RaycastHit _hit;
    private Ray        _ray;
    private Vector3    _objectMoviment;
    private GameObject _currentClicable;
    private float      _movimentMultiplier = 2f;

    private void Start()
    {
        _currentClicable = null;
    }

    void Update()
    {
        CheckForMouseInteractible();
        UpdateObjectMoviment();
        MoveObject();
    }

    private void CheckForMouseInteractible()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_ray, out _hit, 100.0f))
            {
                if (_hit.transform != null)
                {
                    _currentClicable = _hit.transform.gameObject;
                    PrintObjectName();
                }
            }
        }
        else
        {
            _currentClicable = null;
        }

    }

    private void UpdateObjectMoviment()
    {
        if(_currentClicable != null)
        {
            _objectMoviment.x = Input.GetAxis("Mouse X") * _movimentMultiplier;
            _objectMoviment.y = Input.GetAxis("Mouse Y") * _movimentMultiplier;
            _objectMoviment.z = 0;
        }

    }

    private void PrintObjectName()
    {
        print(_currentClicable);
    }

    private void MoveObject() 
    {
        if(_currentClicable != null)
        {
            _currentClicable.transform.Translate(_objectMoviment);
        }
    }


}
