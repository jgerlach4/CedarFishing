using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Look : MonoBehaviour
{

    InputAction lookAction;

    private float lookX;
    private float lookY;
    //private float lookZ;

    // Camera Rotation
    public float mouseSensitivity = 0.2f;
    private Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");

        cameraTransform = Camera.main.transform;

        // Hides the mouse
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookValue = lookAction.ReadValue<Vector2>();

        lookX = lookValue.x * mouseSensitivity;
        lookY -= lookValue.y * mouseSensitivity;

        transform.Rotate(0, lookX, 0);

        lookY = Mathf.Clamp(lookY, -5f, 5f);

        cameraTransform.localRotation = Quaternion.Euler(lookY, 0, 0);
    }
}
