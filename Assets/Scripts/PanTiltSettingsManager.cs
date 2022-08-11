using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTiltSettingsManager : MonoBehaviour
{
    public ExperimentSettings settings;

    PanTiltHandler panTiltHandler;


    void Awake()
    {
        panTiltHandler = GetComponent<PanTiltHandler>();

        panTiltHandler.trackHead = (settings.ui == ExperimentSettings.UI.Screen) ? false : true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
