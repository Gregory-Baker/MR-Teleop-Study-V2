using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class KeyboardCameraInputHandler : MonoBehaviour
{
    KeyboardInput inputActions;

    public float cameraTurnAngle = 45;
    public float cameraTiltAngle = 20;

    public FloatEvent turnCamEvents;
    public FloatEvent tiltCamEvents;
    public UnityEvent centreCamEvents;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new KeyboardInput();
        
    }

    private void OnEnable()
    {
        inputActions.Common.Enable();

        inputActions.Common.TurnCam.performed += TurnCam;
        inputActions.Common.TiltCam.performed += TiltCam;
        inputActions.Common.CentreCam.performed += CentreCam_performed;
    }

    private void OnDisable()
    {
        inputActions.Common.TurnCam.performed -= TurnCam;
        inputActions.Common.TiltCam.performed -= TiltCam;
        inputActions.Common.CentreCam.performed -= CentreCam_performed;

        inputActions.Common.Disable();
    }

    private void TurnCam(InputAction.CallbackContext obj)
    {
        turnCamEvents.Invoke(obj.ReadValue<float>() * cameraTurnAngle);
    }

    private void TiltCam(InputAction.CallbackContext obj)
    {
        tiltCamEvents.Invoke(obj.ReadValue<float>() * cameraTiltAngle);
    }

    private void CentreCam_performed(InputAction.CallbackContext obj)
    {
        centreCamEvents.Invoke();
    }
}
