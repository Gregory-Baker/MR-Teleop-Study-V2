using UnityEngine;
using System.IO;
using Unity.Robotics.ROSTCPConnector;

public class PositionLogger : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    [SerializeField]
    private float movementThreshold = 0.1f;  // Set this value in the editor to your desired threshold

    private string filePath;
    private Vector3 lastPosition;
    private bool headerWritten = false;
    public bool hasMoved = false;

    ROSConnection ros;

    private void Awake()
    {
        filePath = "id_" + id.ToString() + "_positionLog.csv";

        // If the file already exists, delete it to start fresh
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        lastPosition = transform.position;  // Initialize the lastPosition with the current position
    }

    private void OnEnable()
    {
        ros = ROSConnection.GetOrCreateInstance();
    }

    private void Update()
    {
        LogPosition();
    }

    private void LogPosition()
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            // If header hasn't been written, write it
            if (!headerWritten)
            {
                writer.WriteLine("TimeSinceStart,X,Y,Z,HasMoved");
                headerWritten = true;
            }

            // Check if the object has moved more than the threshold from its last position
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
            hasMoved = distanceMoved > movementThreshold;

            // Get the time since the game started
            float timeSinceStart = ros.LastMessageReceivedRealtime;

            // Write the time, position, and movement status of the GameObject to the CSV file
            Vector3 position = transform.position;
            writer.WriteLine($"{timeSinceStart},{position.x},{position.y},{position.z},{hasMoved}");

            // Update the last position for the next frame's comparison
            lastPosition = transform.position;
        }
    }
}
