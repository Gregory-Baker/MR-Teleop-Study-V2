using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;
using System.Linq;

public class SteamVRBasedControllerExample : XRBaseController
{

    [Header("SteamVR Tracking")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    public SteamVR_Action_Pose poseAction = null;
    public bool headPositionCorrection = false;

    [Header("SteamVR Input")]
    public SteamVR_Action_Boolean selectAction = null;
    public SteamVR_Action_Boolean activateAction = null;
    public SteamVR_Action_Boolean interfaceAction = null;

    Vector3 headPosition;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();


    void Start()
    {
        SteamVR.Initialize();

    }



    protected override void UpdateTrackingInput(XRControllerState controllerState)
    {
        if (controllerState != null)
        {

            controllerState.inputTrackingState = InputTrackingState.All;

            Vector3 position = poseAction[inputSource].localPosition;
            if (headPositionCorrection)
            {
                InputTracking.GetNodeStates(nodeStates);
                var headState = nodeStates.FirstOrDefault(node => node.nodeType == XRNode.Head);
                headState.TryGetPosition(out headPosition);
                position -= headPosition;
            }
            controllerState.position = position;

            Quaternion rotation = poseAction[inputSource].localRotation;
            controllerState.rotation = rotation;
        }
    }


    protected override void UpdateInput(XRControllerState controllerState)
    {
        base.UpdateInput(controllerState);
        if (controllerState == null)
            return;

        controllerState.ResetFrameDependentStates();

        controllerState.selectInteractionState.SetFrameState(selectAction[inputSource].state);
        controllerState.activateInteractionState.SetFrameState(activateAction[inputSource].state);
        controllerState.uiPressInteractionState.SetFrameState(interfaceAction[inputSource].state);

    }

    private void SetInteractionState(ref InteractionState interactionState, SteamVR_Action_Boolean_Source action)
    {

        interactionState.activatedThisFrame = action.stateDown;
        interactionState.deactivatedThisFrame = action.stateUp;
        interactionState.SetFrameState(action.state);
    }

}
