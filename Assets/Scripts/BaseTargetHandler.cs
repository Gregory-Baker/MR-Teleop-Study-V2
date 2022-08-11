using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTargetHandler : MonoBehaviour
{

    [Header("Params")]
    public bool singleWaypoint = true;


    [Header("External Objects")]
    public Transform baseLinkTransform;

    public GameObject targetIndicator;
    public GameObject targetIndicatorPrefab;

    [Header("Events")]
    public TransformEvent publishTargetTransformEvents;


    public void SetTargetOrientation()
    {
        Vector3 baseLinkToTarget = transform.position - baseLinkTransform.position;
        if (baseLinkToTarget.magnitude > 0.1)
            transform.rotation = Quaternion.LookRotation(baseLinkToTarget);
    }
    
    public void TurnTarget(float rotationAngle)
    {
        transform.Rotate(Vector3.up, rotationAngle);
    }

    public void SetPosition(Vector3 worldPosition)
    {
        transform.position = worldPosition;
    }

    public void ConfirmTarget ()
    {
        if (singleWaypoint)
        {
            targetIndicator.transform.SetPositionAndRotation(transform.position, transform.rotation);
            
        }
        else
        {
            Instantiate(targetIndicatorPrefab, transform.position, transform.rotation);
        }

        publishTargetTransformEvents.Invoke(transform);
    }

    public void MoveToBaseLink()
    {
        transform.SetPositionAndRotation(baseLinkTransform.position, baseLinkTransform.rotation);
    }

    private void Update()
    {
        
    }
}
