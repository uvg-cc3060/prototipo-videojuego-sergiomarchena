

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

// basic WASD-style movement control
public class FpsMovement : MonoBehaviour
{
    [SerializeField] private Camera headCam;

    public float speed = 5.0f;
    public float gravity = -9.8f;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float rotationVert = 0;
    private float runSpeed = 10f;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        RotateCamera();
    }

    private void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) 
        {
            float deltaX = Input.GetAxis("Horizontal") * runSpeed;
            float deltaZ = Input.GetAxis("Vertical") * runSpeed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, runSpeed);

            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            charController.Move(movement);

        }
        else {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            charController.Move(movement);
        }
    }

    private void RotateCharacter()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
    }

    private void RotateCamera()
    {
        rotationVert -= Input.GetAxis("Mouse Y") * sensitivityVert;
        rotationVert = Mathf.Clamp(rotationVert, minimumVert, maximumVert);

        headCam.transform.localEulerAngles = new Vector3(
            rotationVert, headCam.transform.localEulerAngles.y, 0
        );
    }
}
