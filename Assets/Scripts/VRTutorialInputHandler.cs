using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class VRTutorialInputHandler : MonoBehaviour
{
    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public SteamVR_Action_Boolean nextTutorialAction;

    public UnityEvent nextTutorialEvents;

    void OnEnable()
    {
        nextTutorialAction[inputSource].onStateDown += NextTutorial_onStateDown;
    }

    private void NextTutorial_onStateDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        nextTutorialEvents.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
