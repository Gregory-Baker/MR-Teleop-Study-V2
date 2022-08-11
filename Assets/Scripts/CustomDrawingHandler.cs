using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class CustomDrawingHandler : MonoBehaviour
{
    ROSConnection ros;

    public string[] hideFromZed;

    public List<GameObject> hiddenObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        foreach (var drawingName in hideFromZed)
        {
            StartCoroutine(FindAndHideObjectCoroutine(drawingName));
        }
    }

    private IEnumerator FindAndHideObjectCoroutine(string drawingName)
    {
        GameObject drawingObject = null;
        while (drawingObject == null)
        {
            drawingObject = GameObject.Find(drawingName);
            yield return null;
        }
        hiddenObjects.Add(drawingObject);
        // drawingObject.layer = ZEDLayers.tagInvisibleToZED;
        drawingObject.layer = 16;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
