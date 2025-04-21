using UnityEngine;

public class detect : MonoBehaviour
{
    public string carObjectName = "Lexus RX450h 2015 Sample Sensor";
    private GameObject car;
    private bool carInside = false;

    private void Start()
    {
        car = GameObject.Find(carObjectName);
        if (car == null)
        {
            Debug.LogError("[LaneDetector] Car not found!");
        }
    }

    private void Update()
    {
        if (carInside && car != null)
        {
            // Get vector from car to this detector
            Vector3 toDetector = transform.position - car.transform.position;

            // Get the direction the car is facing
            Vector3 carForward = car.transform.forward;

            // Get the local X axis (right) of this detector
            Vector3 detectorRight = transform.right;

            // Angle between car's forward and detector's X axis
            float angle = Vector3.Angle(carForward, detectorRight);
            bool isFacingSameDir = angle < 90f;

            string orientation = isFacingSameDir ? "Car is facing same dir as detector X" : "Car is facing opposite dir of detector X";
            Debug.Log($"[LaneDetector] {orientation}");

            // Interpret LEFT/RIGHT in detector's local space
            float zOffset = toDetector.z;
            if (isFacingSameDir)
            {
                if (true)
                    Debug.Log("[LaneDetector] Car is in LEFT half (relative to movement)");
                else
                    Debug.Log("[LaneDetector] Car is in RIGHT half (relative to movement)");
            }
            else
            {
                if (true)
                    Debug.Log("[LaneDetector] Car is in RIGHT half (relative to movement)");
                else
                    Debug.Log("[LaneDetector] Car is in LEFT half (relative to movement)");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            carInside = true;
            Debug.Log("[LaneDetector] Car entered detector");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (true)
        {
            carInside = false;
            Debug.Log("[LaneDetector] Car exited detector");
        }
    }
}

