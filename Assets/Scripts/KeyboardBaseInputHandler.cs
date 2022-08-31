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
    public float targetTurnAngle = 5;
    public float targetMoveSpeed = 0.2f;
    public float turnCamSpeed = 2f;

    [Header("External Objects")]
    public GameObject targetObject;
    public Camera zedLeftCamera;

    [Header("Events")]
    public FloatEvent rotateTargetEvents;
    public UnityEvent confirmTargetEvents;
    public UnityEvent stopRobotEvents;
    public FloatEvent moveTargetEvents;
    public UnityEvent moveRobotToTargetEvents;
    public UnityEvent turnCamAndTargetStartedEvents;
    public FloatEvent turnCamAndTargetEvents;
    public UnityEvent turnRobotEvents;


    // Internal Parameters
    sl.ZEDCamera zedCamera;
    KeyboardInput inputActions;
    bool setTargetEnabled = false;
    bool moveTargetEnabled = false;
    bool turnTargetEnabled = false;


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

        inputActions.Base.RobotForwards.performed += RobotForwards_performed;
        inputActions.Base.RobotForwards.canceled += RobotForwards_canceled;

        inputActions.Base.TurnTargetOnTheSpot.performed += TurnTargetOnTheSpot_performed;
        inputActions.Base.TurnTargetOnTheSpot.canceled += TurnTargetOnTheSpot_canceled;
    }


    private void OnDisable()
    {
        inputActions.Base.TargetPositionEnable.performed -= EnableSetTarget;
        inputActions.Base.TargetPositionEnable.canceled -= DisableSetTarget;
        inputActions.Base.TargetPosition.performed -= SetTargetPosition;

        inputActions.Base.TargetRotation.performed -= RotateTarget;

        inputActions.Base.ConfirmTarget.performed -= ConfirmTargetPosition;

        inputActions.Base.StopRobot.performed -= StopRobot;

        inputActions.Base.RobotForwards.performed -= RobotForwards_performed;

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

    private void RobotForwards_performed(InputAction.CallbackContext obj)
    {
        stopRobotEvents.Invoke();
        moveTargetEnabled = true;
        StartCoroutine(MoveTargetForwards(obj));
    }

    private IEnumerator MoveTargetForwards(InputAction.CallbackContext obj)
    {
        while (moveTargetEnabled)
        {
            float distance = obj.ReadValue<float>() * targetMoveSpeed * Time.deltaTime;
            moveTargetEvents.Invoke(distance);
            yield return null;
        }
    }

    private void RobotForwards_canceled(InputAction.CallbackContext obj)
    {
        moveTargetEnabled = false;
        moveRobotToTargetEvents.Invoke();
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

    private void TurnTargetOnTheSpot_performed(InputAction.CallbackContext obj)
    {
        //stopRobotEvents.Invoke();
        turnCamAndTargetStartedEvents.Invoke();
        turnTargetEnabled = true;
        StartCoroutine(TurnCamAndTargetCoroutine(obj));
    }

    private IEnumerator TurnCamAndTargetCoroutine(InputAction.CallbackContext obj)
    {
        while (turnTargetEnabled)
        {
            turnCamAndTargetEvents.Invoke(obj.ReadValue<float>() * turnCamSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void TurnTargetOnTheSpot_canceled(InputAction.CallbackContext obj)
    {
        turnTargetEnabled = false;
        turnRobotEvents.Invoke();
    }


}
