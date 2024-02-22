using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float maxSpeed = 10f;
    public float turnSpeed = 50f;
    public float brakeForce = 20f;

    private float currentSpeed = 0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate acceleration and deceleration
        if (verticalInput > 0f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Calculate movement and rotation
        Vector3 movement = transform.right * currentSpeed * Time.deltaTime; // Use transform.right instead of transform.forward
        float rotation = horizontalInput * turnSpeed * Time.deltaTime;

        // Apply movement and rotation
        transform.Translate(movement, Space.World);
        transform.Rotate(Vector3.up * rotation);

        // Braking
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, brakeForce * Time.deltaTime);
        }
    }
}