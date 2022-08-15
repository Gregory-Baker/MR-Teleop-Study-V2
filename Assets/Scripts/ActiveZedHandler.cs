using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ActiveZedHandler : MonoBehaviour
{
    public ExperimentSettings settings;

    public GameObject zedMono;
    public GameObject zedStereo;

    // Update is called once per frame
    void Update()
    {
        if (settings.ui == ExperimentSettings.UI.Screen)
        {
            zedMono.SetActive(true);
            zedStereo.SetActive(false);
        }
        else if (settings.ui == ExperimentSettings.UI.VR)
        {
            zedMono.SetActive(false);
            zedStereo.SetActive(true);
        }
    }
}
