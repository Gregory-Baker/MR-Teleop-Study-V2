using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class JoystickInputHandler : MonoBehaviour
{
    KeyboardInput inputActions;

    [Header("Params")]
    public float targetMoveSpeed = 0.1f;

    [Header("External Objects")]
    public Transform baseLinkObject;
    public Transform targetObject;

    [Header("Events")]
    public Vector3Event setTargetPositionEvents;
    public UnityEvent playNextTutorialEvents;

    // Internal
    bool moveTargetEnabled = false;
    bool moveTargetVerticalEnabled = false;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new KeyboardInput();
    }

    private void OnEnable()
    {
        inputActions.Arm.Enable();
        inputActions.Common.Enable();

        inputActions.Arm.MoveTargetHorizontalJoy.performed += MoveTargetHorizontalJoy_performed;
        inputActions.Arm.MoveTargetHorizontalJoy.canceled += MoveTargetHorizontalJoy_canceled;
        inputActions.Arm.MoveTargetVerticalJoy.performed += MoveTargetVerticalJoy_performed;
        inputActions.Arm.MoveTargetVerticalJoy.canceled += MoveTargetVerticalJoy_canceled;
        inputActions.Common.NextTutorial.performed += PlayNextTutorial;
    }

    private void OnDisable()
    {
        inputActions.Arm.MoveTargetHorizontalJoy.performed -= MoveTargetHorizontalJoy_performed;
        inputActions.Arm.MoveTargetHorizontalJoy.canceled -= MoveTargetHorizontalJoy_canceled;
        inputActions.Arm.MoveTargetVerticalJoy.performed -= MoveTargetVerticalJoy_performed;
        inputActions.Arm.MoveTargetVerticalJoy.canceled -= MoveTargetVerticalJoy_canceled;

        inputActions.Common.NextTutorial.performed -= PlayNextTutorial;

        inputActions.Common.Disable();
        inputActions.Arm.Disable();
    }


    private void MoveTargetHorizontalJoy_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveTargetEnabled = false;
    }

    private void MoveTargetHorizontalJoy_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        if(!moveTargetEnabled) StartCoroutine(MoveTargetCoroutine(obj));
    }

    IEnumerator MoveTargetCoroutine(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveTargetEnabled = true;
        while (moveTargetEnabled)
        {
            Vector3 translation = new Vector3
            {
                x = obj.ReadValue<Vector2>().x * targetMoveSpeed * Time.deltaTime,
                y = 0,
                z = obj.ReadValue<Vector2>().y * targetMoveSpeed * Time.deltaTime,
            };

            Vector3 position = targetObject.position + baseLinkObject.TransformVector(translation);
            setTargetPositionEvents.Invoke(position);

            yield return null;
        }


    }

    private void MoveTargetVerticalJoy_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!moveTargetVerticalEnabled) StartCoroutine(MoveTargetVerticalCoroutine(obj));
    }

    private IEnumerator MoveTargetVerticalCoroutine(InputAction.CallbackContext obj)
    {
        moveTargetVerticalEnabled = true;
        while (moveTargetVerticalEnabled)
        {
            Vector3 translation = new Vector3
            {
                x = 0,
                y = obj.ReadValue<float>() * targetMoveSpeed * Time.deltaTime,
                z = 0
            };

            Vector3 position = targetObject.position + translation;
            setTargetPositionEvents.Invoke(position);

            yield return null;
        }
    }

    private void MoveTargetVerticalJoy_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveTargetVerticalEnabled = false;
    }


    private void PlayNextTutorial(InputAction.CallbackContext obj)
    {
        Debug.Log("HERE");
        playNextTutorialEvents.Invoke();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
