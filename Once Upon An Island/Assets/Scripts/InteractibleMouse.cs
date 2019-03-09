using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMouse : MonoBehaviour
{
    [SerializeField]
    private float _movimentMultiplier = 2f;
    private Vector3 _objectMoviment;

    public bool move_in_x = false;
    public bool move_in_y = false;
    public bool move_in_z = false;

    public float max_x;
    public float max_y;
    public float max_z;

    public float min_x;
    public float min_y;
    public float min_z;

    public void UpdatePosition()
    {
        UpdateObjectMoviment();
        UpdatePositionItself();
    }

    private void UpdateObjectMoviment()
    {
        _objectMoviment.x = Input.GetAxis("Mouse X") * _movimentMultiplier;
        _objectMoviment.y = Input.GetAxis("Mouse Y") * _movimentMultiplier;
        _objectMoviment.z = 0;
             


        if(_objectMoviment.x <= _objectMoviment.x + max_x)
        {
            _objectMoviment.x = Input.GetAxis("Mouse X") * _movimentMultiplier;
        }
        else if(_objectMoviment.x > _objectMoviment.x + max_x)
        {
            _objectMoviment.x = _objectMoviment.x + max_x;
        }

        if (_objectMoviment.y > _objectMoviment.y + max_y)
        {
            _objectMoviment.y = _objectMoviment.y + max_y;
        }
        if (_objectMoviment.z > _objectMoviment.z + max_z)
        {
            _objectMoviment.z = _objectMoviment.z + max_z;
        }

        if (_objectMoviment.x < _objectMoviment.x - min_x)
        {
            _objectMoviment.x = _objectMoviment.x - min_x;
        }
        if (_objectMoviment.y < _objectMoviment.y - min_y)
        {
            _objectMoviment.y = _objectMoviment.y - min_y;
        }
        if (_objectMoviment.z < _objectMoviment.z - min_z)
        {
            _objectMoviment.z = _objectMoviment.z - min_z;
        }

    }

    private void UpdatePositionItself()
    {
        if (gameObject != null)
        {
            gameObject.transform.Translate(_objectMoviment);
        }
    }

}
