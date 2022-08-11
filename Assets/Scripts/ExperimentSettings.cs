using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Interface Settings")]
public class ExperimentSettings : ScriptableObject
{
    public enum ControlMethod
    {
        Waypoint,
        Direct,
    }

    public enum UI
    {
        Screen,
        VR
    }

    public enum Condition
    {
        Tutorial,
        Trial,
        Test
    }

    public int participantID;

    public ControlMethod controlMethod;

    public UI ui;

    public Condition condition;

    public float delay = 0f;

}
