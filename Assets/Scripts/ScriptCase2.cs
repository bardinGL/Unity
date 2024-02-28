using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptCase2 : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody; // Assign in the inspector
    [SerializeField] private GameObject inclinedPanel; // Assign in the inspector
    [SerializeField] private GameObject sphereGameObject; // Assign in the inspector
    [SerializeField] private TextMeshProUGUI velocityText; // Assign in the inspector
    [SerializeField] private TextMeshProUGUI accelerationText; // Assign in the inspector
    [SerializeField] private float coefficientOfRollingResistance = 0.02f; // Adjust based on your needs

    private Vector3 previousVelocity = Vector3.zero;
    private float updateInterval = 0.1f;
    private float timer;

    private void Start()
    {
        if (sphereRigidbody == null) Debug.LogError("Sphere Rigidbody is not assigned.", this);
        if (inclinedPanel == null) Debug.LogError("Inclined Panel is not assigned.", this);
        if (sphereGameObject == null) Debug.LogError("Sphere GameObject is not assigned.", this);
        if (velocityText == null || accelerationText == null) Debug.LogError("UI Text elements are not assigned.", this);

        timer = updateInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            UpdatePhysicsData();
            timer = updateInterval;
        }
    }

    private void UpdatePhysicsData()
    {
        // Dynamically get the sphere's radius based on its scale
        float sphereRadius = sphereGameObject.transform.localScale.x / 2.0f;

        // Dynamically calculate the incline angle from the inclined panel GameObject
        float inclineAngleRadians = inclinedPanel.transform.eulerAngles.x * Mathf.Deg2Rad;

        // Physics calculations
        Vector3 currentVelocity = sphereRigidbody.velocity;
        Vector3 acceleration = (currentVelocity - previousVelocity) / updateInterval;

        // Display the calculated data
        velocityText.text = $"Velocity for case 2: {currentVelocity.magnitude:F2} m/s";
        accelerationText.text = $"Acceleration for case 2: {acceleration.magnitude:F2} m/s²";

        // Update previousVelocity for the next frame's calculation
        previousVelocity = currentVelocity;
    }
}