using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class TrackRosTF : MonoBehaviour
{
    ROSConnection ros;

    [SerializeField]
    string objectName;

    [Header("Params")]

    [SerializeField]
    bool trackPosition = true;

    [SerializeField]
    bool trackRotation = true;


    [SerializeField]
    Vector3 positionOffset = new Vector3(0, 0, 0);

    [SerializeField]
    float rotationOffset = 0;


    GameObject objectToTrack = null;
    

    private void OnEnable()
    {
        ros = ROSConnection.GetOrCreateInstance();
    }

    public void SetTrackingObject()
    {
        if (objectName != "")
        {
            objectToTrack = GameObject.Find(objectName);
        }
    }

    public void SetRotationOffset(float offsetNew)
    {
        rotationOffset = (Mathf.Abs(offsetNew) < 150) ? offsetNew : rotationOffset;
    }

    public void ChangeRotationOffset(float turnAngle)
    {
        float offsetNew = rotationOffset + turnAngle;

        rotationOffset = (Mathf.Abs(offsetNew) < 150) ? offsetNew : rotationOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (objectToTrack != null)
        {   
            if (trackPosition) 
            {
                transform.position = objectToTrack.transform.position + positionOffset;
            } 
            if (trackRotation)
            {
                transform.rotation = objectToTrack.transform.rotation;
                transform.Rotate(Vector3.up, rotationOffset);
            }
            
        }
        else
        {
            SetTrackingObject();
        }
    }
}
