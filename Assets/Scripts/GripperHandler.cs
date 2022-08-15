using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.Control;
using RosMessageTypes.Actionlib;
using RosMessageTypes.KortexDriver;
using Unity.Robotics.ROSTCPConnector;
using System;
using System.Runtime.CompilerServices;

public enum GripperState
{
    Open,
    Closed
}

public class GripperHandler : MonoBehaviour
{
    ROSConnection ros;

    public GripperState state;

    [Header("Params")]  
    public string gripperStatusService;
    public int pollStatusFrequency = 1;

    [Header("Events")]
    public RosMessageEvent openGripperEvents;
    public RosMessageEvent closeGripperEvents;


    private void Awake()
    {
        ros = ROSConnection.GetOrCreateInstance();

        ros.RegisterRosService<GetMeasuredGripperMovementRequest, GetMeasuredGripperMovementResponse>(gripperStatusService);
    }

    public void OnEnable()
    {
        
        StartCoroutine(PollGripperState(gripperStatusService, pollStatusFrequency));
    }

    private IEnumerator PollGripperState(string service, int updateRate = 1)
    {
        float interval = 1 / updateRate;

        while (true)
        {
            yield return new WaitForSeconds(interval);
            var grip_status_req = new GetMeasuredGripperMovementRequest();
            grip_status_req.input.mode = 3;
            ros.SendServiceMessage<GetMeasuredGripperMovementResponse>(service, grip_status_req, UpdateGripperState);
        }
    }


    private void UpdateGripperState(GetMeasuredGripperMovementResponse response)
    {
        state = (response.output.finger[0].value > 0.5) ? GripperState.Closed : GripperState.Open;
    }

    public void OpenGripper()
    {
        GripperCommandActionGoal actionGoal = new GripperCommandActionGoal();
        actionGoal.goal.command.position = 0.0;
        openGripperEvents.Invoke(actionGoal);
        state = GripperState.Open;
    }

    public void CloseGripper()
    {
        GripperCommandActionGoal actionGoal = new GripperCommandActionGoal();
        actionGoal.goal.command.position = 0.8;
        openGripperEvents.Invoke(actionGoal);
        state = GripperState.Closed;
    }

    public void ActuatueGripper()
    {
        if (state == GripperState.Open)
        {
            CloseGripper();
        }
        else
        {
            OpenGripper();
        }
    }

}
