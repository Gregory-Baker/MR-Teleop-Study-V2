using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class VRCameraInputHandler : MonoBehaviour
{
    [Header("Variables")]
    public float cameraTurnAngle = 30f;


    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    [Header("SteamVR Events")]
    public SteamVR_Action_Boolean centreCamAction;
    public SteamVR_Action_Boolean turnCamLeftAction;
    public SteamVR_Action_Boolean turnCamRightAction;
    public SteamVR_Action_Boolean turnRobotToCamAction;

    [Header("Events")]
    public UnityEvent centreCamEvents;
    public FloatEvent turnCamLeftEvents;
    public FloatEvent turnCamRightEvents;
    public UnityEvent turnRobotToCamEvents;

    void OnEnable()
    {
        centreCamAction[inputSource].onStateDown += CentreCam;
        turnCamLeftAction[inputSource].onStateDown += TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown += TurnCamRight;
        turnRobotToCamAction[inputSource].onStateDown += TurnRobotToCam;
    }

    void OnDisable()
    {
        centreCamAction[inputSource].onStateDown -= CentreCam;
        turnCamLeftAction[inputSource].onStateDown -= TurnCamLeft;
        turnCamRightAction[inputSource].onStateDown -= TurnCamRight;
        turnRobotToCamAction[inputSource].onStateDown -= TurnRobotToCam;
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

    private void TurnRobotToCam(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        turnRobotToCamEvents.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
