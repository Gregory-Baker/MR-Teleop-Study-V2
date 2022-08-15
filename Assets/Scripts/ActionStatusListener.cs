using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Actionlib;
using System.Linq;
using UnityEngine.Events;

public enum ActionStatus
{
    Active,
    Cancelled,
    Successful
}

public class ActionStatusListener : MonoBehaviour
{

    ROSConnection ros;

    public string actionStatusTopicName;

    public Color32 goalSuccessColour = Color.white;
    public Color32 goalFailureColour = Color.red;
    public Color32 goalActiveColour = Color.green;

    public ColorEvent actionStatusEvents;

    ActionStatus actionStatus;
    Color actionStatusColour;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        if (actionStatusTopicName != "")
            ros.Subscribe<GoalStatusArrayMsg>(actionStatusTopicName, ActionStatusCallback);
    }

    public void ActionStatusCallback(GoalStatusArrayMsg msg)
    {
        if (msg.status_list.Length > 0)
        {
            var status = msg.status_list.Last().status;
            if (status == 3)
            {
                actionStatus = ActionStatus.Successful;
                actionStatusColour = goalSuccessColour;

            }
            else if (status == 1)
            {
                actionStatus = ActionStatus.Active;
                actionStatusColour = goalActiveColour;
            }
            else
            {
                actionStatus = ActionStatus.Cancelled;
                actionStatusColour = goalFailureColour;
            }

            actionStatusEvents.Invoke(actionStatusColour);
        }
    }



}
