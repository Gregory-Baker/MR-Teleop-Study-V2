using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class KeyboardBaseInputHandler : MonoBehaviour
{

    [Header("Params")]
    public float targetTurnAngle = 10;

    [Header("External Objects")]
    public GameObject targetObject;
    public Camera zedLeftCamera;

    [Header("Events")]
    public FloatEvent rotateTargetEvents;
    public UnityEvent confirmTargetEvents;
    public UnityEvent stopRobotEvents;


    // Internal Parameters
    sl.ZEDCamera zedCamera;
    KeyboardInput inputActions;
    bool setTargetEnabled = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new KeyboardInput();
        zedCamera = FindObjectOfType<ZEDManager>().zedCamera;
    }


    private void OnEnable()
    {
        inputActions.Base.Enable();

        inputActions.Base.TargetPositionEnable.performed += EnableSetTarget;
        inputActions.Base.TargetPositionEnable.canceled += DisableSetTarget;
        inputActions.Base.TargetPosition.performed += SetTargetPosition;

        inputActions.Base.TargetRotation.performed += RotateTarget;

        inputActions.Base.ConfirmTarget.performed += ConfirmTargetPosition;

        inputActions.Base.StopRobot.performed += StopRobot;
    }

    private void OnDisable()
    {
        inputActions.Base.TargetPositionEnable.performed -= EnableSetTarget;
        inputActions.Base.TargetPositionEnable.canceled -= DisableSetTarget;
        inputActions.Base.TargetPosition.performed -= SetTargetPosition;

        inputActions.Base.TargetRotation.performed -= RotateTarget;

        inputActions.Base.ConfirmTarget.performed -= ConfirmTargetPosition;

        inputActions.Base.StopRobot.performed -= StopRobot;


        inputActions.Base.Disable();
    }

    private void EnableSetTarget(InputAction.CallbackContext obj)
    {
        setTargetEnabled = true;
    }

    private void DisableSetTarget(InputAction.CallbackContext obj)
    {
        setTargetEnabled = false;
    }

    private void SetTargetPosition(InputAction.CallbackContext obj)
    {
        if (setTargetEnabled && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePosition = obj.ReadValue<Vector2>();

            mousePosition.x *= (float)zedCamera.ImageWidth / (float)Screen.width;
            mousePosition.y *= (float)zedCamera.ImageHeight / (float)Screen.height;

            Ray ray = zedLeftCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction);
                Vector3 position = hit.point;
                position.y = targetObject.transform.position.y;
                targetObject.transform.position = position;

            }
        }
    }

    private void RotateTarget(InputAction.CallbackContext obj)
    {
        float turnAngle = Mathf.Sign(obj.ReadValue<float>()) * targetTurnAngle;
        rotateTargetEvents.Invoke(turnAngle);
    }

    public void ConfirmTargetPosition(InputAction.CallbackContext obj)
    {
        confirmTargetEvents.Invoke();
    }

    private void StopRobot(InputAction.CallbackContext obj)
    {
        stopRobotEvents.Invoke();
    }


}
