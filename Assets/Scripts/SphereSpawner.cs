using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [Header("Sphere Settings")]
    public float sphereDiameter = 0.5f; // Diameter of the sphere
    public Color sphereColor = Color.white; // Color of the sphere

    [Header("Spawn Settings")]
    public float spawnInterval = 1.0f; // Time interval between spawns in seconds

    private GameObject parentObject; // Parent object for all spheres
    private float elapsedTime = 0.0f; // Elapsed time since last spawn

    void Start()
    {
        // Create parent object for all spheres
        parentObject = new GameObject("SpheresParent");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnInterval)
        {
            SpawnSphere();
            elapsedTime = 0.0f;
        }
    }

    void SpawnSphere()
    {
        // Create sphere at game object's location
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position;
        sphere.transform.localScale = new Vector3(sphereDiameter, sphereDiameter, sphereDiameter);
        
        // Set sphere color
        Renderer rend = sphere.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = sphereColor;
        }

        // Parent the sphere to the parent object
        sphere.transform.SetParent(parentObject.transform);
    }
}

