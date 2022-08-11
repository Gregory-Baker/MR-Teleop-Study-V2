using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticipantHandler : MonoBehaviour
{
    public ExperimentSettings interfaceSettings;

    public List<GameObject> vrOnlyGameObjects;

    public List<GameObject> screenOnlyGameObjects;

    public List<GameObject> waypointOnlyGameObjects;

    public List<GameObject> directOnlyGameObjects;

    public List<GameObject> trialOnlyGameObjects;

    public List<GameObject> tutorialOnlyGameObjects;

    private void Awake()
    {
        // Interface specific objects enable/disable
        if (interfaceSettings.ui == ExperimentSettings.UI.Screen)
        {
            // foreach (var gameObject in screenOnlyGameObjects) gameObject.SetActive(true);
            foreach (var gameObject in vrOnlyGameObjects) gameObject.SetActive(false);
        }
        if (interfaceSettings.ui == ExperimentSettings.UI.VR)
        {
            foreach (var gameObject in screenOnlyGameObjects) gameObject.SetActive(false);
            // foreach (var gameObject in vrOnlyGameObjects) gameObject.SetActive(true);
        }

        // Control specific objects enable/disable
        if (interfaceSettings.controlMethod == ExperimentSettings.ControlMethod.Waypoint)
        {
            // foreach (var gameObject in waypointOnlyGameObjects) gameObject.SetActive(true);
            foreach (var gameObject in directOnlyGameObjects) gameObject.SetActive(false);
        }
        if (interfaceSettings.controlMethod == ExperimentSettings.ControlMethod.Direct)
        {
            foreach (var gameObject in waypointOnlyGameObjects) gameObject.SetActive(false);
            // foreach (var gameObject in directOnlyGameObjects) gameObject.SetActive(true);
        }

        // Test condition objects enable/disable
        if (interfaceSettings.condition == ExperimentSettings.Condition.Trial)
        {
            //foreach (var gameObject in trialOnlyGameObjects) gameObject.SetActive(true);
            foreach (var gameObject in tutorialOnlyGameObjects) gameObject.SetActive(false);
        }
        if (interfaceSettings.condition == ExperimentSettings.Condition.Tutorial)
        {
            foreach (var gameObject in trialOnlyGameObjects) gameObject.SetActive(false);
            //foreach (var gameObject in tutorialOnlyGameObjects) gameObject.SetActive(true);
        }
        if (interfaceSettings.condition == ExperimentSettings.Condition.Test)
        {
            foreach (var gameObject in trialOnlyGameObjects) gameObject.SetActive(false);
            foreach (var gameObject in tutorialOnlyGameObjects) gameObject.SetActive(false);
        }
    }
}
