using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RosMessageTypes.Actionlib;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{

}

[System.Serializable]
public class TransformEvent : UnityEvent<Transform>
{

}

[System.Serializable]
public class Vector3Event : UnityEvent<Vector3>
{

}

[System.Serializable]
public class ColorEvent : UnityEvent<Color>
{

}

[System.Serializable]
public class RosMessageEvent : UnityEvent<Message>
{

}

[System.Serializable]
public class GoalStatusArrayEvent : UnityEvent<GoalStatusArrayMsg>
{

}

