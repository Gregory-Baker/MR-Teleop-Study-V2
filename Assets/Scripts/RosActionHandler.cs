using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using RosMessageTypes.Actionlib;
using RosMessageTypes.KinovaCustom;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

public class RosActionHandler : MonoBehaviour
{
    ROSConnection ros;

    public string actionNamespace;
    public string actionName;

    public RosMessageEvent resultEvents;
    public RosMessageEvent feedbackEvents;
    public GoalStatusArrayEvent statusEvents;

    RosTopicState actionGoalPublisher;
    RosTopicState actionCancelPublisher;

    private void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        actionGoalPublisher = ros.RegisterPublisher(actionNamespace + "/goal", actionName + "ActionGoal");
        actionCancelPublisher = ros.RegisterPublisher<GoalIDMsg>(actionNamespace + "/cancel");

        ros.SubscribeByMessageName(actionNamespace + "/result", actionName + "ActionResult", ResultCallback);
        ros.SubscribeByMessageName(actionNamespace + "/feedback", actionName + "ActionFeedback", FeedbackCallback);
        ros.Subscribe<GoalStatusArrayMsg>(actionNamespace + "/status", StatusCallback);
        
    }

    public void PublishActionGoal(Unity.Robotics.ROSTCPConnector.MessageGeneration.Message goal)
    {
        actionGoalPublisher.Publish(goal);
    }

    public void CancelActionGoal()
    {
        GoalIDMsg cancel = new GoalIDMsg();
        actionCancelPublisher.Publish(cancel);
    }

    private void ResultCallback(Message result)
    {
        resultEvents.Invoke(result);
    }

    private void FeedbackCallback(Message feedback)
    {
        feedbackEvents.Invoke(feedback);
    }

    private void StatusCallback(GoalStatusArrayMsg status)
    {
        statusEvents.Invoke(status);
    }
}
