using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class KeyboardCommonInputHandler : MonoBehaviour
{
    KeyboardInput inputActions;

    public UnityEvent swithControlEvents;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new KeyboardInput();
    }

    private void OnEnable()
    {
        inputActions.Common.Enable();

        inputActions.Common.SwitchControlMode.performed += SwitchControlMode_performed;
    }

    private void OnDisable()
    {
        inputActions.Common.Disable();
    }


    private void SwitchControlMode_performed(InputAction.CallbackContext obj)
    {
        swithControlEvents.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
