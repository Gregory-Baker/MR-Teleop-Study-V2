using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DynamixelPanTilt;
using UnityEngine.XR;
using Valve.VR;
using System.Linq;
using UnityEngine.UIElements;

public class PanTiltPublisher : MonoBehaviour
{
    ROSConnection ros;

    public string topicName = "/head_rot";

    [Header("External Objects")]
    public PanTiltHandler panTiltHandler;

    // Inernal
    float timeElapsed;
    RosTopicState publisher;
    PanTiltAngleMsg headRotMsg = new PanTiltAngleMsg();

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();

        publisher = ros.RegisterPublisher<PanTiltAngleMsg>(topicName);
    }


    void FixedUpdate()
    {    
        if (ros.isActiveAndEnabled)
        {
            // publisher = ros.RegisterPublisher<PanTiltAngleMsg>(topicName);

            headRotMsg.pan_angle = panTiltHandler.panAngle;
            headRotMsg.tilt_angle = panTiltHandler.tiltAngle;

            publisher.Publish(headRotMsg);

            timeElapsed = 0;
        }
    }
}
