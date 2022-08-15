using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class KeyboardArmInputHandler : MonoBehaviour
{
    [Header("Params")]
    public float targetVerticalStep = 0.02f;

    [Header("External Objects")]
    public Transform targetObject;
    public Camera zedLeftCamera;

    [Header("Events")]
    public UnityEvent confirmTargetEvents;
    public UnityEvent pickObjectEvents;
    public UnityEvent placeObjectEvents;
    public UnityEvent stopArmEvents;
    public UnityEvent armToHomeEvents;
    public UnityEvent openGripperEvents;
    public UnityEvent closeGripperEvents;
    public Vector3Event setPositionEvents; 

    // Internal Params
    KeyboardInput inputActions;
    sl.ZEDCamera zedCamera;
    bool moveTargetEnabled = false;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new KeyboardInput();
        zedCamera = FindObjectOfType<ZEDManager>().zedCamera;
    }

    private void OnEnable()
    {
        inputActions.Arm.Enable();

        inputActions.Arm.ConfirmTarget.performed += ConfirmTarget_performed;
        inputActions.Arm.PickObject.performed += PickObject_performed;
        inputActions.Arm.PlaceObject.performed += PlaceObject_performed;
        inputActions.Arm.StopArm.performed += StopArm_performed;
        inputActions.Arm.OpenGripper.performed += OpenGripper_performed;
        inputActions.Arm.CloseGripper.performed += CloseGripper_performed;
        inputActions.Arm.ArmToHome.performed += ArmToHome_performed;

        inputActions.Arm.MoveTargetEnable.performed += MoveTargetEnable_performed;
        inputActions.Arm.MoveTargetEnable.canceled += MoveTargetEnable_canceled;
        inputActions.Arm.MoveTargetHorizontal.performed += MoveTargetHorizontal_performed;
        inputActions.Arm.MoveTargetVertical.performed += MoveTargetVertical_performed;
    }

    private void OnDisable()
    {
        inputActions.Arm.ConfirmTarget.performed -= ConfirmTarget_performed;
        inputActions.Arm.PickObject.performed -= PickObject_performed;
        inputActions.Arm.PlaceObject.performed -= PlaceObject_performed;
        inputActions.Arm.StopArm.performed -= StopArm_performed;
        inputActions.Arm.OpenGripper.performed -= OpenGripper_performed;
        inputActions.Arm.CloseGripper.performed -= CloseGripper_performed;
        inputActions.Arm.ArmToHome.performed += ArmToHome_performed;

        inputActions.Arm.MoveTargetEnable.performed -= MoveTargetEnable_performed;
        inputActions.Arm.MoveTargetEnable.canceled -= MoveTargetEnable_canceled;
        inputActions.Arm.MoveTargetHorizontal.performed -= MoveTargetHorizontal_performed;
        inputActions.Arm.MoveTargetVertical.performed -= MoveTargetVertical_performed;

        inputActions.Arm.Disable();
    }

    private void ConfirmTarget_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        confirmTargetEvents.Invoke();
    }

    private void StopArm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        stopArmEvents.Invoke();
    }

    private void PlaceObject_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        placeObjectEvents.Invoke();
    }

    private void PickObject_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        pickObjectEvents.Invoke();
    }

    private void OpenGripper_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        openGripperEvents.Invoke();
    }

    private void CloseGripper_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        closeGripperEvents.Invoke();
    }

    private void ArmToHome_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        armToHomeEvents.Invoke();
    }

    private void MoveTargetVertical_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector3 position = targetObject.position + Mathf.Sign(obj.ReadValue<float>()) * targetVerticalStep * Vector3.up;
        setPositionEvents.Invoke(position);
    }

    private void MoveTargetHorizontal_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (moveTargetEnabled && !EventSystem.current.IsPointerOverGameObject())
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
                position.y = targetObject.position.y;
                setPositionEvents.Invoke(position);
            }
        }
    }

    private void MoveTargetEnable_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveTargetEnabled = false;
    }

    private void MoveTargetEnable_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveTargetEnabled = true;
    }
}
