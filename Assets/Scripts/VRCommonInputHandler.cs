using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class VRCommonInputHandler : MonoBehaviour
{
    [Header("Variables")]
    public float cameraTurnAngle = 30f;


    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    [Header("SteamVR Events")]
    public SteamVR_Action_Boolean changeControlModeAction;
    public SteamVR_Action_Boolean centreCamAction;
    public SteamVR_Action_Boolean turnCamLeftAction;
    public SteamVR_Action_Boolean turnCamRightAction;

    [Header("Events")]
    public UnityEvent changeControlModeEvents;
    public UnityEvent centreCamEvents;
    public FloatEvent turnCamLeftEvents;
    public FloatEvent turnCamRightEvents;

    void OnEnable()
    {
        changeControlModeAction[inputSource].onStateDown += ChangeControlMode;
        centreCamAction[inputSource].onStateDown += CentreCam;
        turnCamLeftAction[inputSource].onStateDown += TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown += TurnCamRight;
    }

    void OnDisable()
    {
        changeControlModeAction[inputSource].onStateDown += ChangeControlMode;
        centreCamAction[inputSource].onStateDown += CentreCam;
        turnCamLeftAction[inputSource].onStateDown += TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown += TurnCamRight;
    }

    private void ChangeControlMode(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        changeControlModeEvents.Invoke();
    }

    private void CentreCam(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        centreCamEvents.Invoke();
    }


    private void TurnCamLeft(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        turnCamLeftEvents.Invoke(-cameraTurnAngle);
    }

    private void TurnCamRight(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        turnCamRightEvents.Invoke(cameraTurnAngle);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
