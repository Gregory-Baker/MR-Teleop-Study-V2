using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedRecorder : MonoBehaviour
{
    public ExperimentSettings settings;
    public ZEDManager zedManager;
    public string folder;

    string participantID;
    string control;
    string ui;

    public bool recording;

    // Start is called before the first frame update
    void Start()
    {
        recording = false;

        participantID = settings.participantID.ToString();
        control = settings.controlMethod.ToString();
        ui = settings.ui.ToString();

        if (settings.condition == ExperimentSettings.Condition.Trial)
        {
            if (zedManager != null)
            {
                zedManager.OnZEDReady += StartRecording;

            }
        }
    }

    private void StartRecording()
    {
        recording = true;

        string datetime = DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month + "_" + DateTime.Now.Date.Day + "-" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + "_" + DateTime.Now.TimeOfDay.Seconds;
        string outfile = folder + "id_" + participantID + "/" + participantID + "_" + control + "_" + ui + "_" + datetime + ".svo";
        Debug.Log("Outfile: " + outfile);
        zedManager.zedCamera.EnableRecording(outfile);

    }
    void OnDisable()
    {
        if (recording && zedManager!=null)
        {
            zedManager.zedCamera.DisableRecording();
        }
    }
}
