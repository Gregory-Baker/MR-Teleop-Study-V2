using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveObjectHandler : MonoBehaviour
{
    public ExperimentSettings settings;

    public List<GameObject> vrOnlyGameObjects;

    public List<GameObject> screenOnlyGameObjects;

    public List<GameObject> waypointOnlyGameObjects;

    public List<GameObject> directOnlyGameObjects;

    public List<GameObject> trialOnlyGameObjects;

    public List<GameObject> tutorialOnlyGameObjects;

    private void Awake()
    {
        // Disable
        // Interface specific objects enable/disable
        if (settings.ui == ExperimentSettings.UI.Screen) foreach (var gameObject in vrOnlyGameObjects) gameObject.SetActive(false);
        if (settings.ui == ExperimentSettings.UI.VR) foreach (var gameObject in screenOnlyGameObjects) gameObject.SetActive(false);

        // Control specific objects enable/disable
        if (settings.controlMethod == ExperimentSettings.ControlMethod.Waypoint) foreach (var gameObject in directOnlyGameObjects) gameObject.SetActive(false);
        if (settings.controlMethod == ExperimentSettings.ControlMethod.Direct) foreach (var gameObject in waypointOnlyGameObjects) gameObject.SetActive(false);

        // Test condition objects enable/disable
        if (settings.condition == ExperimentSettings.Condition.Trial) foreach (var gameObject in tutorialOnlyGameObjects) gameObject.SetActive(false);
        if (settings.condition == ExperimentSettings.Condition.Tutorial) foreach (var gameObject in trialOnlyGameObjects) gameObject.SetActive(false);
        if (settings.condition == ExperimentSettings.Condition.Test)
        {
            foreach (var gameObject in trialOnlyGameObjects) gameObject.SetActive(false);
            foreach (var gameObject in tutorialOnlyGameObjects) gameObject.SetActive(false);
        }
    }

    private void Update()
    {


    }
}
