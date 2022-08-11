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

    [Header("Select Target")]
    public SteamVR_Action_Boolean selectTargetAction;
    public UnityEvent selectTargetDownEvents;
    public UnityEvent selectTargetActiveEvents;
    public UnityEvent selectTargetUpEvents;

    [Header("Rotate Target")]
    public SteamVR_Action_Vector2 rotateTargetAction;
    public FloatEvent rotateTargetEvents;

    [Header("Confirm Target")]
    public SteamVR_Action_Boolean confirmTargetAction;
    public UnityEvent confirmTargetEvents;

    [Header("Stop Robot")]
    public SteamVR_Action_Boolean stopRobotAction;
    public UnityEvent stopRobotEvents;

    [Header("Rotate Camera")]
    public SteamVR_Action_Boolean centreCamAction;
    public UnityEvent centreCamEvents;

    public SteamVR_Action_Boolean turnCamLeftAction;
    public UnityEvent turnCamLeftEvents;

    public SteamVR_Action_Boolean turnCamRightAction;
    public UnityEvent turnCamRightEvents;



    private void OnEnable()
    {
        selectTargetAction[inputSource].onStateDown += SelectTargetDown;
        selectTargetAction[inputSource].onState += SelectTargetActive;
        selectTargetAction[inputSource].onStateUp += SelectTargetUp;
        rotateTargetAction[inputSource].onAxis += RotateTarget;
        confirmTargetAction[inputSource].onStateDown += ConfirmTarget;
        stopRobotAction[inputSource].onStateDown += StopRobot;
        centreCamAction[inputSource].onStateDown += CentreCam;
        turnCamLeftAction[inputSource].onStateDown += TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown += TurnCamRight;
    }


    private void OnDisable()
    {
        selectTargetAction[inputSource].onStateDown -= SelectTargetDown;
        selectTargetAction[inputSource].onState += SelectTargetActive;
        selectTargetAction[inputSource].onStateUp -= SelectTargetUp;
        rotateTargetAction[inputSource].onAxis -= RotateTarget;
        confirmTargetAction[inputSource].onStateDown -= ConfirmTarget;
        centreCamAction[inputSource].onStateDown -= CentreCam;
        stopRobotAction[inputSource].onStateDown -= StopRobot;
        turnCamLeftAction[inputSource].onStateDown -= TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown -= TurnCamRight;
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

        if (Mathf.Abs(directionChange) < Mathf.PI/4) // && selectTargetAction[inputSource].state != true)
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

    private void CentreCam(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        centreCamEvents.Invoke();
    }


    private void TurnCamLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        turnCamLeftEvents.Invoke();
    }

    private void TurnCamRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        turnCamRightEvents.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
