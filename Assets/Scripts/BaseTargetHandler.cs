using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.MoveBase;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.KinovaCustom;
using UnityEngine.Events;

public class BaseTargetHandler : MonoBehaviour
{

    [Header("Params")]
    public bool singleWaypoint = true;


    [Header("External Objects")]
    public Transform baseLinkTransform;

    public GameObject targetIndicator;
    public GameObject targetIndicatorPrefab;

    public PanTiltHandler panTiltHandler;

    [Header("Events")]
    public RosMessageEvent publishTargetTransformEvents;
    public UnityEvent stopRobotEvents;
    public RosMessageEvent moveDistanceEvents;
    public RosMessageEvent turnRobotEvents;

    [Header("State")]
    public bool moveBaseActive;

    // Internal
    float baseHeadingPrevious;
    float targetDistance;

    public void SetTargetOrientation()
    {
        Vector3 baseLinkToTarget = transform.position - baseLinkTransform.position;
        if (baseLinkToTarget.magnitude > 0.1)
            transform.rotation = Quaternion.LookRotation(baseLinkToTarget);
    }
    
    public void TurnTarget(float rotationAngle)
    {
        transform.Rotate(Vector3.up, rotationAngle);
    }

    public void SetPosition(Vector3 worldPosition)
    {
        transform.position = worldPosition;
    }

    public void ConfirmTarget ()
    {
        if (singleWaypoint)
        {
            targetIndicator.transform.SetPositionAndRotation(transform.position, transform.rotation);
            
        }
        else
        {
            Instantiate(targetIndicatorPrefab, transform.position, transform.rotation);
        }

        moveBaseActive = true;
        publishTargetTransformEvents.Invoke(CreateTargetMessage(transform));
    }

    public void StopRobot()
    {
        stopRobotEvents.Invoke();
    }

    public MoveBaseActionGoal CreateTargetMessage(Transform transform)
    {
        var goal = new MoveBaseActionGoal();
        goal.goal.target_pose.header.frame_id = "map";
        goal.goal.target_pose.pose.position = transform.position.To<FLU>();
        goal.goal.target_pose.pose.orientation = transform.rotation.To<FLU>();
        return goal;
    }

    public void MoveToBaseLink()
    {
        targetDistance = 0;
        transform.SetPositionAndRotation(baseLinkTransform.position, baseLinkTransform.rotation);
    }

    public void MoveTargetDistance(float distance)
    {
        var translation = new Vector3(0, 0, distance);
        targetDistance += distance;
        transform.Translate(translation, Space.Self);
    }

    public void MoveRobotDistance(float distance)
    {
        if (!moveBaseActive)
        {
            var goal = new MoveDistanceActionGoal();
            goal.goal.move_distance = distance;
            moveDistanceEvents.Invoke(goal);
        }
    }

    public void TurnRobotToCam()
    {
        if (!moveBaseActive && panTiltHandler.panOffset != 0)
        {
            var goal = new TurnAngleActionGoal();
            goal.goal.turn_angle = -panTiltHandler.panAngle * Mathf.Deg2Rad;
            baseHeadingPrevious = baseLinkTransform.eulerAngles.y;

            turnRobotEvents.Invoke(goal);
            StartCoroutine(TurnCamWithRobot());
        }

    }

    private IEnumerator TurnCamWithRobot()
    {
        while (Mathf.Abs(panTiltHandler.panAngle) > 1)
        {
            float baseHeadingDiff = baseLinkTransform.eulerAngles.y - baseHeadingPrevious;
            if (baseHeadingDiff > 180) baseHeadingDiff -= 360;
            if (baseHeadingDiff < -180) baseHeadingDiff += 360;
            panTiltHandler.panAngle -= baseHeadingDiff;
            yield return null;
        }
        panTiltHandler.panOffset = 0;
    }

    public void UpdateMoveBaseState(Unity.Robotics.ROSTCPConnector.MessageGeneration.Message result)
    {
        moveBaseActive = false;
    }

    private void Update()
    {
        
    }
}
