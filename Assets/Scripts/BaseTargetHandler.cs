using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.MoveBase;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine.Events;

public class BaseTargetHandler : MonoBehaviour
{

    [Header("Params")]
    public bool singleWaypoint = true;


    [Header("External Objects")]
    public Transform baseLinkTransform;

    public GameObject targetIndicator;
    public GameObject targetIndicatorPrefab;

    [Header("Events")]
    public RosMessageEvent publishTargetTransformEvents;
    public UnityEvent stopRobotEvents;


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
        transform.SetPositionAndRotation(baseLinkTransform.position, baseLinkTransform.rotation);
    }

    private void Update()
    {
        
    }
}
