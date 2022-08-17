using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class RosPublisherHandler : MonoBehaviour
{
    ROSConnection ros;

    public string topic;

    [Tooltip("Needs package and message name, as it appears when you do 'rostopic info ...' cmd e.g. 'geometry_msgs/Twist'")]
    public string messageDescription;

    RosTopicState publisher;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        publisher = ros.RegisterPublisher(topic, messageDescription);
    }

    public void PublishMessage(Unity.Robotics.ROSTCPConnector.MessageGeneration.Message msg)
    {
        publisher.Publish(msg);
    }
}