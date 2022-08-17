using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;
using RosMessageTypes.KinovaCustom;
using JetBrains.Annotations;
using System;

public class PanTiltHandler : MonoBehaviour
{
    public bool trackHead = true;

    [Header("Offset")]
    public float panOffset = 0;
    public float tiltOffset = 15;

    [Header("Read Only")]
    public float panAngle;
    public float tiltAngle;

    [Header("External Objects")]
    public Transform baseLinkObject;

    private Quaternion headRotation;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();
    float prevPanAngle = 0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 angles = Vector3.zero;
        if (trackHead)
        {
            InputTracking.GetNodeStates(nodeStates);
            var headState = nodeStates.FirstOrDefault(node => node.nodeType == XRNode.Head);
            headState.TryGetRotation(out headRotation);
            angles = headRotation.eulerAngles;
        }

        panAngle = angles.y + panOffset;
        tiltAngle = angles.x + tiltOffset;

        // Change from 0-360 to -180-180 range
        if (panAngle > 180) panAngle -= 360;
        if (tiltAngle > 180) tiltAngle -= 360;

        // Check panAngle hasn't gone round the bend
        float panChange = Mathf.Abs(panAngle - prevPanAngle);
        panAngle = (panChange < 270) ? panAngle : prevPanAngle;
    }

    public void CentreCameraPan()
    {
        panOffset = 0;
    }

    public void CentreCameraTilt()
    {
        tiltOffset = 0;
    }

    public void TurnCam(float turnAngle)
    {
        float panOffsetNew = panOffset + turnAngle;

        panOffset = (Mathf.Abs(panOffsetNew) < 150) ? panOffsetNew : panOffset; 
    }

    public void TiltCam(float turnAngle)
    {
        float tiltOffsetNew = tiltOffset + turnAngle;

        tiltOffset = (Mathf.Abs(tiltOffsetNew) < 90) ? tiltOffsetNew : tiltOffset;

    }


    public IEnumerator CentreCameraPanCoroutine(float speed)
    {
        while (Mathf.Abs(panOffset) > 1)
        {
            panOffset -= Mathf.Sign(panOffset) * speed * Time.deltaTime;
            yield return null;
        }
    }
}
