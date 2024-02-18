using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotoVR.SDK.API;
using RotoVR.SDK.Components;
using RotoVR.SDK.Enum;
using RotoVR.SDK.Model;

public class TestRoto : MonoBehaviour
{

    [SerializeField] private RotoBehaviour rotoBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        rotoBehaviour.Connect();
        rotoBehaviour.OnConnectionStatusChanged += RotoBehaviourOnOnConnectionStatusChanged;
    }

    private void RotoBehaviourOnOnConnectionStatusChanged(ConnectionStatus status)
    {
        
        if (status == ConnectionStatus.Connected)
        {
            rotoBehaviour.SwitchMode(ModeType.SimulationMode);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
