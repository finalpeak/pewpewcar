using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float maxSpeed = 10f;
    public float baseRotationSpeed = 180f;
    public float turnSpeedMultiplier = 0.5f;

    private float currentSpeed = 0f;

    void Update()
    {
        // Get input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement and rotation
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f).normalized;
        Vector3 rotation = new Vector3(0f, horizontalInput, 0f);

        // Apply acceleration to the current speed
        currentSpeed += verticalInput * acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Apply deceleration when not accelerating
        if (verticalInput == 0f)
        {
            float decelerationAmount = deceleration * Time.deltaTime;
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, decelerationAmount);
        }

        // Calculate the movement based on the current speed
        Vector3 velocity = transform.right * currentSpeed;

        // Move the object based on the input
        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Calculate the turn speed based on the current speed
        float currentTurnSpeed = baseRotationSpeed * Mathf.Clamp01(1f - Mathf.Abs(currentSpeed / maxSpeed) * turnSpeedMultiplier);

        // Rotate the object based on the input and turn speed
        transform.Rotate(rotation * currentTurnSpeed * Time.deltaTime);
    }
}