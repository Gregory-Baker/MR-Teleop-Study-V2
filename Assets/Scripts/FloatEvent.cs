using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{

}

[System.Serializable]
public class TransformEvent : UnityEvent<Transform>
{

}
