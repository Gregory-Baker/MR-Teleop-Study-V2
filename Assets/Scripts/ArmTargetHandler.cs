using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.KinovaCustom;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine.Events;
using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor;

public class ArmTargetHandler : MonoBehaviour
{
    [Header("External Objects")]
    public Transform baseLinkTransform;
    public Transform targetTransform;
    public GripperHandler gripper;

    [Header("Offsets")]
    public Vector3 resetPositionOffset; // Position where target goes when arm control is activated
    // Offset for discrepency between 
    public Vector3 staticPositionOffset; 
    public Vector3 staticRotationOffset;
    public float prePickVerticalOffset = 0.125f;
    public float prePlaceVerticalOffset = 0.3f;

    [Header("Events")]
    public RosMessageEvent poseGoalEvents;
    public RosMessageEvent cartesianGoalEvents;
    public RosMessageEvent jointGoalEvents;
    public RosMessageEvent armToHomeEvents;
    public RosMessageEvent pickObjectFullEvents;
    public RosMessageEvent placeObjectFullEvents;
    public RosMessageEvent pickObjectBasicEvents;
    public RosMessageEvent placeObjectBasicEvents;
    public UnityEvent stopArmEvents;

    [Header("Params")]
    int armDoF = 7;
    public string[] jointNames = new string[7];

    [Header("Target Limits")]
    public float targetForwardMax = 0.9f;
    public float targetForwardMin = 0.0f;
    public float targetLRMax = 0.4f;
    public float targetHeightMax = 0.6f;
    public float targetHeightMin = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private PoseMsg GetTargetPose()
    {
        return new PoseMsg
        {
            position = (baseLinkTransform.InverseTransformPoint(targetTransform.position) + staticPositionOffset).To<FLU>(),
            orientation = (Quaternion.Euler(targetTransform.localRotation.eulerAngles + staticRotationOffset)).To<FLU>()
        };
    }

    private PickObjectFullActionGoal GeneratePickObjectFullMsg()
    {
        PickObjectFullActionGoal goal = new PickObjectFullActionGoal();

        goal.goal.pre_pick_pose = GetTargetPose();

        return goal;
    }

    public JointStateMsg GenerateJointStateMsg(string[] jointNames, double[] jointPositions)
    {
        var goal = new JointStateMsg();
        goal.name = jointNames;
        goal.position = jointPositions;
        return goal;
    }

    // TODO: currently relative to parent, which is offset from base link
    public void SetTargetPosition (Vector3 position)
    {
        targetTransform.position = position;

        Vector3 positionLimited = targetTransform.localPosition;
        positionLimited.x = (positionLimited.x < -targetLRMax) ? -targetLRMax : positionLimited.x;
        positionLimited.x = (positionLimited.x > targetLRMax) ? targetLRMax : positionLimited.x;
        positionLimited.y = (positionLimited.y < targetHeightMin) ? targetHeightMin : positionLimited.y;
        positionLimited.y = (positionLimited.y > targetHeightMax) ? targetHeightMax : positionLimited.y;
        positionLimited.z = (positionLimited.z < targetForwardMin) ? targetForwardMin : positionLimited.z;
        positionLimited.z = (positionLimited.z > targetForwardMax) ? targetForwardMax : positionLimited.z;

        targetTransform.localPosition = positionLimited;
    }

    public void ResetTargetPosition()
    {
        targetTransform.localPosition = resetPositionOffset;
    }

    public void MoveToPoseGoal()
    {
        var goal = GetTargetPose();
        poseGoalEvents.Invoke(goal);
    }

    public void MoveToCartesianGoal()
    {
        var goal = GetTargetPose();
        cartesianGoalEvents.Invoke(goal);
    }

    public void MoveToJointGoal(double[] jointPositions)
    {
        var goal = GenerateJointStateMsg(jointNames, jointPositions);
        jointGoalEvents.Invoke(goal);
    }

    public void MoveToHome()
    {
        double[] jointPositions = { 1.516, -1.177, -0.880, 2.153, -0.812, 1.898, -0.798 };
        var goal = GenerateJointStateMsg(jointNames, jointPositions);
        armToHomeEvents.Invoke(goal);
    }

    public void MoveToSidePosition()
    {
        double[] jointPositions = { 1.338, -1.298, -1.128, 1.519, -1.331, 2.064, -1.7562 };
        var goal = GenerateJointStateMsg(jointNames, jointPositions);
        jointGoalEvents.Invoke(goal);
    }

    public void PickFull()
    {
        var goal = GeneratePickObjectFullMsg();
        goal.goal.pre_pick_pose.position.z += prePickVerticalOffset;
        pickObjectFullEvents.Invoke(goal);
    }

    public void PlaceFull()
    {
        var goal = GeneratePickObjectFullMsg();
        goal.goal.pre_pick_pose.position.z += prePlaceVerticalOffset;
        placeObjectFullEvents.Invoke(goal);
    }

    // Moves to target position, then picks or places the barrel vertically down
    public void PickOrPlaceFull()
    {
        if (gripper.state == GripperState.Open) PickFull();
        else PlaceFull();
    }

    // Picks or places the barrel vertically down
    public void PickOrPlaceBasic()
    {
        var goal = new PlaceObjectActionGoal();

        if (gripper.state == GripperState.Open)
            pickObjectBasicEvents.Invoke(goal);
        else
            placeObjectBasicEvents.Invoke(goal);
    }

    
    public void StopArm()
    {
        stopArmEvents.Invoke();
    }
}
