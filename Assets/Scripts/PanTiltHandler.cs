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
    public bool fixHeading = false;

    [Header("Offset")]
    public float panOffsetStart = 0;
    public float tiltOffsetStart = 15;
    [HideInInspector]
    public float panOffset;
    [HideInInspector]
    public float tiltOffset;

    [Header("Read Only")]
    public float panAngle;
    public float tiltAngle;

    [Header("External Objects")]
    public Transform baseLinkTransform;
    public BaseTargetHandler baseTargetHandler;

    [Header("Events")]
    public FloatEvent turnCamEvents;

    

    private Quaternion headRotation;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();
    float prevPanAngle = 0f;

    float headingPrev;


    private void Start()
    {
        panOffset = panOffsetStart;
        tiltOffset = tiltOffsetStart;
    }

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
        prevPanAngle = panAngle;


        if (fixHeading && Mathf.Abs(panOffset) < 1)
        {
            panOffset = 0;
            fixHeading = false;
        }

        if (fixHeading)
        {
            float baseHeadingDiff = baseLinkTransform.eulerAngles.y - headingPrev;
            if (baseHeadingDiff > 180) baseHeadingDiff -= 360;
            if (baseHeadingDiff < -180) baseHeadingDiff += 360;
            TurnCam(-baseHeadingDiff);

        }
        headingPrev = baseLinkTransform.eulerAngles.y;
    }

    public void CentreCameraPan()
    {
        panOffset = 0;
    }

    public void CentreCameraTilt()
    {
        tiltOffset = tiltOffsetStart;
    }

    public void TurnCam(float turnAngle)
    {
        float panOffsetNew = panOffset + turnAngle;

        panOffset = (Mathf.Abs(panOffsetNew) <= 179) ? panOffsetNew : panOffset;

        turnCamEvents.Invoke(panOffset);

        if (baseTargetHandler.moveBaseActive)
        {
            fixHeading = true;
        }
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
