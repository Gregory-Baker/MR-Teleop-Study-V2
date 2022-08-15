using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

public class MoveGroupInterfacePublisher : MonoBehaviour
{
    ROSConnection ros;

    public string poseGoalTopic;
    public string cartesianGoalTopic;
    public string jointGoalTopic;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        ros.RegisterPublisher<PoseMsg>(poseGoalTopic);
        ros.RegisterPublisher<PoseMsg>(cartesianGoalTopic);
        ros.RegisterPublisher<JointStateMsg>(jointGoalTopic);


    }

    public void PublishPoseGoal(Message message)
    {
        ros.Publish(poseGoalTopic, message);
    }

    public void PublishCartesianGoal(Message message)
    {
        ros.Publish(cartesianGoalTopic, message);
    }

    public void PublishJointGoal(Message message)
    {
        ros.Publish(jointGoalTopic, message);
    }
}
