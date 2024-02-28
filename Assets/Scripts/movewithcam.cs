using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewithcam : MonoBehaviour
{
    public Transform target; // The sphere you want to follow
    public Vector3 offset; // The offset distance between the camera and the sphere

    void LateUpdate()
    {
        // Set the camera's position to the target's position plus the offset
        transform.position = target.position + offset;

        // Make the camera look at the target (sphere)
        transform.LookAt(target);
    }
}