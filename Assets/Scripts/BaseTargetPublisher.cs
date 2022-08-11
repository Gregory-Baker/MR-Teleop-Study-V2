using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Nav;
using RosMessageTypes.Actionlib;
using RosMessageTypes.MoveBase;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;

public class BaseTargetPublisher : MonoBehaviour
{
    ROSConnection ros;

    public float delay = 0f;

    [Header("Move Base")]
    [SerializeField]
    string moveBaseGoal = null;

    [SerializeField]
    string moveBaseCancel = null;

    [SerializeField]
    string moveBaseStatus = null;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        // Move Base
        ros.RegisterPublisher<MoveBaseActionGoal>(moveBaseGoal);
        ros.RegisterPublisher<GoalIDMsg>(moveBaseCancel);
    }

    public void PublishWithDelay(string topic, Unity.Robotics.ROSTCPConnector.MessageGeneration.Message message, float delay = 0)
    {
        StartCoroutine(PublishWithDelayCoroutine(topic, message, delay));
    }

    private IEnumerator PublishWithDelayCoroutine(string topic, Unity.Robotics.ROSTCPConnector.MessageGeneration.Message message, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        ros.Publish(topic, message);
    }

    public void PublishTarget(Transform transform)
    {
        var goal = new MoveBaseActionGoal();
        goal.goal.target_pose.header.frame_id = "map";
        goal.goal.target_pose.pose.position = transform.position.To<FLU>();
        goal.goal.target_pose.pose.orientation = transform.rotation.To<FLU>();
        PublishWithDelay(moveBaseGoal, goal, delay);
    }

    public void CancelActionGoal(string topic)
    {
        var cancelMsg = new GoalIDMsg();
        PublishWithDelay(topic, cancelMsg, delay);
    }

    public void StopRobot()
    {
        CancelActionGoal(moveBaseCancel);
    }
}
