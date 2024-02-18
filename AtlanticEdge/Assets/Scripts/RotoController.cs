using RotoVR.SDK.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotoController : MonoBehaviour
{
    [SerializeField]
    private RotoBehaviour _rotoBehaviour;

    [SerializeField]
    private Transform _rotoTargetDirection;

    [SerializeField]
    private Transform _rotoVisualisationTransform;

    [SerializeField]
    private float _turnSpeed = 60;

    private float _currentAngle;

    [SerializeField]
    private bool _isConnected;

    // Start is called before the first frame update
    void Start()
    {
        _isConnected = false;
        
        _rotoBehaviour.OnConnectionStatusChanged += OnRotoConnectStatusChange;

       // while (!_isConnected)
        //{
            Debug.Log("attempting to connect to roto vr chair...");
            _rotoBehaviour.Connect();
        //}

        //_rotoBehaviour.Calibration();

        _rotoBehaviour.OnDataChanged += OnRotoDataChanged;
    }

    private void OnRotoDataChanged(RotoVR.SDK.Model.RotoDataModel data)
    {
        float angle = data.Angle;

        _rotoVisualisationTransform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    private void OnRotoConnectStatusChange(RotoVR.SDK.Enum.ConnectionStatus status)
    {
        if(status == RotoVR.SDK.Enum.ConnectionStatus.Connected)
        {
            _isConnected = true;
            _rotoBehaviour.SwitchMode(RotoVR.SDK.Enum.ModeType.SimulationMode);
        }

        Debug.Log("Status update: " + status.ToString());
    }


    private void Update()
    {
        if(!_isConnected)
        {
            return;
        }

        if(_turningLeft)
        {
            _currentAngle -= _turnSpeed * Time.deltaTime;

            _rotoTargetDirection.rotation = Quaternion.Euler(new Vector3(0, _currentAngle, 0));
        }

        if (_turningRight)
        {
            _currentAngle += _turnSpeed * Time.deltaTime;

            _rotoTargetDirection.rotation = Quaternion.Euler(new Vector3(0, _currentAngle, 0));
        }
    }

    private bool _turningRight;
    private bool _turningLeft;

    public void OnRightButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _turningRight = true;
        }
        else if (context.canceled)
        {
            _turningRight = false;
        }
    }

    public void OnLeftButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _turningLeft = true;
        }
        else if (context.canceled)
        {
            _turningLeft = false;
        }
    }
    
    public void startLeftRotation()
    {
        _turningLeft = true;
    }
    
    public void startRightRotation()
    {
        _turningRight = true;
    }
    
    public void stopRotation()
    {
        _turningLeft = false;
        _turningRight = false;
        _rotoTargetDirection.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
