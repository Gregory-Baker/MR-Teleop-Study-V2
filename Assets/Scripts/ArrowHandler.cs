using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{


    public GripperHandler gripperHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gripperHandler.state == GripperState.Open)
        {
            transform.localPosition = new Vector3(0, -0.125f, 0);
        }
        else
        {
            transform.localPosition = new Vector3(0, -0.3f, 0);
        }


    }
}
