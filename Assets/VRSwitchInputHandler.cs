using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class VRSwitchInputHandler : MonoBehaviour
{
    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    [Header("SteamVR Events")]
    public SteamVR_Action_Boolean changeControlModeAction;

    [Header("Events")]
    public UnityEvent changeControlModeEvents;


    void OnEnable()
    {
        changeControlModeAction[inputSource].onStateDown += ChangeControlMode;
    }

    void OnDisable()
    {
        changeControlModeAction[inputSource].onStateDown -= ChangeControlMode;
    }

    private void ChangeControlMode(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        changeControlModeEvents.Invoke();
    }
}
