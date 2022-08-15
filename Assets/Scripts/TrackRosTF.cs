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
    Vector3 rotationOffset = new Vector3();


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

    public void SetHeadingOffset(float offsetNew)
    {
        rotationOffset.y = (Mathf.Abs(offsetNew) < 150) ? offsetNew : rotationOffset.y;
    }

    public void ChangeHeadingOffset(float turnAngle)
    {
        float offsetNew = rotationOffset.y + turnAngle;

        rotationOffset.y = (Mathf.Abs(offsetNew) < 150) ? offsetNew : rotationOffset.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (objectToTrack != null)
        {   
            if (trackPosition) 
            {
                transform.position = objectToTrack.transform.position;
                transform.Translate(positionOffset, Space.Self);
            } 
            if (trackRotation)
            {
                transform.rotation = objectToTrack.transform.rotation;
                transform.Rotate(rotationOffset);
            }
            
        }
        else
        {
            SetTrackingObject();
        }
    }
}
