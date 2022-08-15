using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    public Transform targetObject;

    [Header("Position Mask")]
    public Vector3 positionMask = Vector3.one;

    [Header("Rotation Mask")]
    public Vector3 rotationMask = Vector3.one;

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            transform.position = Vector3.Scale(targetObject.position, positionMask);
            Vector3 rotation = Vector3.Scale(targetObject.rotation.eulerAngles, rotationMask);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
