using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // The player's transform to follow
    [SerializeField] private Vector3 offset; // Offset to adjust the camera position
    [SerializeField] private float smoothSpeed = 5f; // How smoothly the camera follows the player

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired camera position
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
