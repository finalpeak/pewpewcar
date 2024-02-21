using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    public float rightClamp = 180f;
    public float leftClamp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Locking Cursor to screen and making invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //Clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Rotation around y axis (Look left and right)
        yRotation += mouseX;

        //Clamp rotation
        yRotation = Mathf.Clamp(yRotation, leftClamp, rightClamp);

        //Apply rotations to transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
