using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMouse : MonoBehaviour
{
    private CameraRotation _cameraInstance;
    private GameObject _player;

    private int            _counter;

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

 
    private void Start()
    {
        GetCameraInstance();
        GetPlayer();
    }

    public void UpdatePosition()
    {
        UpdateObjectMoviment();
        UpdatePositionItself();
    }

    private void UpdateObjectMoviment()
    {

        //TODO full remake needed: go PlayerMoviment.cs for references
        switch (_cameraInstance.cameraPosition)
        {
            case 1:
                _objectMoviment.x = Input.GetAxis("Mouse X") * _movimentMultiplier;
                _objectMoviment.y = Input.GetAxis("Mouse Y") * _movimentMultiplier;
                break;
            case 2:
                _objectMoviment.z = Input.GetAxis("Mouse X") * _movimentMultiplier;
                _objectMoviment.z = Input.GetAxis("Mouse Y") * _movimentMultiplier;
                break;
            case 3:
                _objectMoviment.x = -Input.GetAxis("Mouse X") * _movimentMultiplier;
                _objectMoviment.y = -Input.GetAxis("Mouse Y") * _movimentMultiplier;
                break;
            case 4:
                _objectMoviment.x = -Input.GetAxis("Mouse Y") * _movimentMultiplier;
                _objectMoviment.y = Input.GetAxis("Mouse X") * _movimentMultiplier;
                break;
        }

        //NOT WORKING diferent input handling
        /*if(_cameraInstance.turnSideGetter > 0)
        {
            _counter += 1;
        }

        if (_cameraInstance.turnSideGetter < 0)
        {
            _objectMoviment.y = Input.GetAxis("Mouse X") * _movimentMultiplier;
        }
        else if (_cameraInstance.turnSideGetter > 0)
        {
            _objectMoviment.y = -Input.GetAxis("Mouse X") * _movimentMultiplier;
        }
        */
    }

    private void UpdatePositionItself()
    {
        if (gameObject != null)
        {
            gameObject.transform.Translate(_objectMoviment);
        }
    }

    //TODO NEEDS FIX(idk why this crap dont work, brakeys done the sameeee
    //Move player with the moving object
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            _player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.transform.parent = null;
        }
    }

    private void GetCameraInstance()
    {
        GameObject cameraInstance = GameObject.FindWithTag("Camera");

        if (cameraInstance != null)
        {
            _cameraInstance = cameraInstance.GetComponent<CameraRotation>();
        }
    }

    private void GetPlayer()
    {
        _player = GameObject.FindWithTag("Player");
    }
}
