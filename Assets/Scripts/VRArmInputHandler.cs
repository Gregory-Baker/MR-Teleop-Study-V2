using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;

public class VRArmInputHandler : MonoBehaviour
{
    [Header("SteamVR Input Source")]
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    public SteamVR_ActionSet actionSet;
    public SteamVR_Action_Pose controllerPose;

    [Header("SteamVR Actions")]
    public SteamVR_Action_Boolean moveTargetAction;
    public SteamVR_Action_Boolean confirmTargetAction;
    public SteamVR_Action_Boolean stopArmAction;

    [Header("Events")]
    public Vector3Event setTargetPositionEvents;
    public UnityEvent confirmTargetEvents;
    public UnityEvent stopArmEvents;


    [Header("External Objects")]
    public Transform armTarget;
    public Transform baseLink;
    public Transform controllerLink;


    // Internal Variables
    Vector3 initialControllerPosition = Vector3.zero;
    Vector3 initialTargetPosition = Vector3.zero;

    void OnEnable()
    {
        actionSet.Activate();
        moveTargetAction[inputSource].onStateDown += MoveTarget_onStateDown;
        moveTargetAction[inputSource].onState += MoveTarget_onState;
        confirmTargetAction[inputSource].onStateDown += ConfirmTarget_onStateDown;
        stopArmAction[inputSource].onStateDown += StopArm_onStateDown;

    }

    void OnDisable()
    {
        moveTargetAction[inputSource].onStateDown -= MoveTarget_onStateDown;
        moveTargetAction[inputSource].onState -= MoveTarget_onState;
        actionSet.Deactivate();
    }
    private void MoveTarget_onStateDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        initialControllerPosition = controllerLink.position;
        initialTargetPosition = armTarget.position;
    }

    private void MoveTarget_onState(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Vector3 controllerTranslation = controllerLink.position - initialControllerPosition;
        Vector3 position = initialTargetPosition + controllerTranslation;
        setTargetPositionEvents.Invoke(position);
    }

    private void ConfirmTarget_onStateDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        confirmTargetEvents.Invoke();
    }

    private void StopArm_onStateDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        stopArmEvents.Invoke();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
