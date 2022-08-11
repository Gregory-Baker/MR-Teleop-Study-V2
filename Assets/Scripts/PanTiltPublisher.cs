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

    public string topicName = "head_rot";
    public float publishMessageFrequency = 0f;

    [Header("External Objects")]
    public PanTiltHandler panTiltHandler;

    // Inernal
    float timeElapsed;
    RosTopicState publisher;
    PanTiltAngleMsg headRotMsg;

    void Awake()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        publisher = ros.RegisterPublisher<PanTiltAngleMsg>(topicName);

        headRotMsg = new PanTiltAngleMsg();
    }

    
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (ros.isActiveAndEnabled && timeElapsed > publishMessageFrequency)
        {
            headRotMsg.pan_angle = panTiltHandler.panAngle;
            headRotMsg.tilt_angle = panTiltHandler.tiltAngle;

            publisher.Publish(headRotMsg);

            timeElapsed = 0;
        }
    }
}
