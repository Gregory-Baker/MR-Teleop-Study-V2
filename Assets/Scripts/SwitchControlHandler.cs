using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchControlHandler : MonoBehaviour
{
    public enum ControlMode
    {
        Arm,
        Base
    }

    public ControlMode controlMode;

    [Header("Activate/Deactivate Objects")]
    public GameObject[] baseOnlyObjects;
    public GameObject[] armOnlyObjects;

    [Header("Events")]
    public UnityEvent baseControlEvents;
    public UnityEvent armControlEvents;

    // Start is called before the first frame update
    void Start()
    {   
        SwitchToBaseControl();
    }

    public void SwitchControlMode()
    {
        if (controlMode == ControlMode.Base)
        {
            SwitchToArmControl();
        }
        else if (controlMode == ControlMode.Arm)
        {
            SwitchToBaseControl();
        }
    }

    private void SwitchToBaseControl()
    {
        controlMode = ControlMode.Base;
        foreach (var item in baseOnlyObjects) item.SetActive(true);
        foreach (var item in armOnlyObjects) item.SetActive(false);
        baseControlEvents.Invoke();
    }

    public void SwitchToArmControl()
    {
        controlMode = ControlMode.Arm;
        foreach (var item in baseOnlyObjects) item.SetActive(false);
        foreach (var item in armOnlyObjects) item.SetActive(true);
        armControlEvents.Invoke();
    }
}
