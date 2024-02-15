using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        // Get the Oculus Touch controller input
        float forwardMovement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        float strafeMovement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;

        // Calculate the movement direction based on the controller's forward direction
        Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;

        // Move the player
        Vector3 moveDirection = forward * forwardMovement + right * strafeMovement;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

}
