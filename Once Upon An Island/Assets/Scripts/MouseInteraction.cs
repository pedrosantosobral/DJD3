using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    private RaycastHit          _hit;
    private Ray                 _ray;
    private Vector3             _objectMoviment;
    private InteractibleMouse   _desiredObject;


    void Update()
    {
        CheckForMouseInteractible();
        UpdateInteractibleMoviment();
    }

    private void CheckForMouseInteractible()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_ray, out _hit, 100.0f))
            {
                if (_hit.transform != null && _hit.collider.gameObject.GetComponent<InteractibleMouse>() != null) 
                {
                   InteractibleMouse newInteractible = _hit.collider.gameObject.GetComponent<InteractibleMouse>();
                   SetInteractible(newInteractible);
                }
            }
        }
        else
        {
            _desiredObject = null;
        }
    }

    private void SetInteractible(InteractibleMouse newInteractible)
    {
        _desiredObject = newInteractible;
    }

    private void UpdateInteractibleMoviment()
    {
        if(_desiredObject !=  null)
        {
            _desiredObject.UpdatePosition();
        }
    }


}
