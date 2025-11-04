using UnityEngine;
using UnityEngine.InputSystem;

public class Cast : MonoBehaviour
{
    InputAction interactAction;
    InputAction moveAction;
    InputAction click;

    private float movementX;
    private float movementY;

    private MonoBehaviour move;

    public GameObject bobberGuide;
    public GameObject bobber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        moveAction = InputSystem.actions.FindAction("Move");
        click = InputSystem.actions.FindAction("Attack");

        move = GetComponent<Example>();

    }

    // Update is called once per frame
    void Update()
    {
        // If E is pressed disable movement, and set the bobber guide to be active,and at your current position
        // The bobber guide is a placeholder for the actual bobber that you will cast later
        if (interactAction.triggered)
        {
            move.enabled = false;
            bobberGuide.transform.position = this.transform.position;
            bobberGuide.transform.position -= new Vector3(0, 1, 0);

            bobberGuide.SetActive(true);
        }

        // Check to see if the move script is disabled
        // If it is, then you are able to move the bobber guide with WASD
        if (move.enabled == false)
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();

            movementX = moveValue.x;
            movementY = moveValue.y;

            Vector3 movement = (transform.right * movementX + transform.forward * movementY).normalized;
            Vector3 targetVelocity = movement * (float)0.02;

            bobberGuide.transform.position += targetVelocity;

            // Actual cast of the bobber with a left click of the mouse
            // The bobber will go to where the bobber guide is
            if (click.triggered)
            {
                bobberGuide.SetActive(false);
                bobber.SetActive(true);
                bobber.transform.position = bobberGuide.transform.position;
            }


        }


    }
}
