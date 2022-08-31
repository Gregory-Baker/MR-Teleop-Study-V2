using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using System.Net;

public class JoystickStatePublisherCustom : MonoBehaviour
{
    ROSConnection ros;
    RosTopicState joyPublisher;

    public string joyTopic;

    public SwitchControlHandler controlHandler;

    public int rightShoulderVal;
     

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        joyPublisher = ros.RegisterPublisher<JoyMsg>(joyTopic);

    }

    void FixedUpdate()
    {
        var joyMsg = new JoyMsg();
        joyMsg.axes = new float[8];
        joyMsg.buttons = new int[11];

        joyMsg.axes[3] = -Gamepad.current.leftStick.ReadValue().x;
        joyMsg.axes[4] = Gamepad.current.leftStick.ReadValue().y;
        joyMsg.axes[2] = Gamepad.current.leftTrigger.ReadValue();
        joyMsg.axes[0] = -Gamepad.current.rightStick.ReadValue().x;
        joyMsg.axes[1] = Gamepad.current.rightStick.ReadValue().y;
        joyMsg.axes[5] = Gamepad.current.rightTrigger.ReadValue();
        joyMsg.axes[6] = -Gamepad.current.dpad.ReadValue().x;
        joyMsg.axes[7] = Gamepad.current.dpad.ReadValue().y;

        joyMsg.buttons[0] = (int)Gamepad.current.aButton.ReadValue();
        joyMsg.buttons[1] = (int)Gamepad.current.bButton.ReadValue();
        joyMsg.buttons[2] = (int)Gamepad.current.xButton.ReadValue();
        joyMsg.buttons[3] = (int)Gamepad.current.yButton.ReadValue();
        joyMsg.buttons[5] = (int)Gamepad.current.leftShoulder.ReadValue();
        joyMsg.buttons[4] = rightShoulderVal;
        joyMsg.buttons[6] = (int)Gamepad.current.selectButton.ReadValue();
        joyMsg.buttons[7] = (int)Gamepad.current.startButton.ReadValue();
        joyMsg.buttons[8] = 0;
        joyMsg.buttons[9] = (int)Gamepad.current.leftStickButton.ReadValue();
        joyMsg.buttons[10] = (int)Gamepad.current.rightStickButton.ReadValue();

        joyPublisher.Publish(joyMsg);
    }

    private void Update()
    {
        if (controlHandler.controlMode == SwitchControlHandler.ControlMode.Base)
        {
            rightShoulderVal = 1;
        }
        else
        {
            rightShoulderVal = 0;
        }
    }
}
