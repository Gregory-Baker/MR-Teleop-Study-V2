using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;


public class VRBaseInputHandler : MonoBehaviour
{
    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    public SteamVR_ActionSet actionSet;

    [Header("SteamVR Events")]
    public SteamVR_Action_Boolean selectTargetAction;
    public SteamVR_Action_Vector2 rotateTargetAction;
    public SteamVR_Action_Boolean confirmTargetAction;
    public SteamVR_Action_Boolean stopRobotAction;
    public SteamVR_Action_Boolean moveRobotForwardAction;
    public SteamVR_Action_Boolean moveRobotBackwardAction;

    [Header("Events")]
    public UnityEvent selectTargetDownEvents;
    public UnityEvent selectTargetActiveEvents;
    public UnityEvent selectTargetUpEvents;
    public FloatEvent rotateTargetEvents;
    public UnityEvent confirmTargetEvents;
    public UnityEvent stopRobotEvents;
    public FloatEvent moveTargetEvents;
    public FloatEvent moveRobotEvents;

    [Header("Params")]
    public float targetMoveSpeed = 0.2f;

    //Internal
    float targetDistance = 0;

    private void OnEnable()
    {
        actionSet.Activate();
        selectTargetAction[inputSource].onStateDown += SelectTargetDown;
        selectTargetAction[inputSource].onState += SelectTargetActive;
        selectTargetAction[inputSource].onStateUp += SelectTargetUp;
        rotateTargetAction[inputSource].onAxis += RotateTarget;
        confirmTargetAction[inputSource].onStateDown += ConfirmTarget;
        stopRobotAction[inputSource].onStateDown += StopRobot;

        moveRobotForwardAction[inputSource].onStateDown += MoveRobotStarted;
        moveRobotForwardAction[inputSource].onState += MoveTargetForward;
        moveRobotForwardAction[inputSource].onStateUp += MoveRobotEnded;

        moveRobotBackwardAction[inputSource].onStateDown += MoveRobotStarted;
        moveRobotBackwardAction[inputSource].onState += MoveTargetBackward;
        moveRobotBackwardAction[inputSource].onStateUp += MoveRobotEnded;
    }

    private void OnDisable()
    {
        selectTargetAction[inputSource].onStateDown -= SelectTargetDown;
        selectTargetAction[inputSource].onState += SelectTargetActive;
        selectTargetAction[inputSource].onStateUp -= SelectTargetUp;
        rotateTargetAction[inputSource].onAxis -= RotateTarget;
        confirmTargetAction[inputSource].onStateDown -= ConfirmTarget;
        stopRobotAction[inputSource].onStateDown -= StopRobot;
        actionSet.Deactivate();
    }


    private void MoveRobotStarted(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        targetDistance = 0;
        stopRobotEvents.Invoke();
    }

    private void MoveTargetForward(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        float distance = targetMoveSpeed * Time.deltaTime;
        targetDistance += distance;
        moveTargetEvents.Invoke(distance);
    }

    private void MoveTargetBackward(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        float distance = -targetMoveSpeed * Time.deltaTime;
        targetDistance += distance;
        moveTargetEvents.Invoke(distance);
    }

    private void MoveRobotEnded(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        moveRobotEvents.Invoke(targetDistance);
    }

    private void SelectTargetDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selectTargetDownEvents.Invoke();
    }

    private void SelectTargetActive(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selectTargetActiveEvents.Invoke();
    }

    private void SelectTargetUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selectTargetUpEvents.Invoke();
    }

    private void RotateTarget(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        Vector2 axisLast = axis - delta;
        float directionLast = -Mathf.Atan2(axisLast.y, axisLast.x);
        float direction = -Mathf.Atan2(axis.y, axis.x);
        float directionChange = direction - directionLast;

        if (Mathf.Abs(directionChange) < Mathf.PI/4) 
        {
            rotateTargetEvents.Invoke(directionChange * Mathf.Rad2Deg * 0.5f);
        }
    }

    private void ConfirmTarget(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        confirmTargetEvents.Invoke();
    }


    private void StopRobot(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        stopRobotEvents.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
