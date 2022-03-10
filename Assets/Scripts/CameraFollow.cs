using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        // Target that the camera follows
        [SerializeField]
        private Transform target;
        // Position of the camera relative to the target
        [SerializeField]
        private Vector3 offset;
        // Follow speed
        private float followSpeed = 0.125f;
        // Velocity
        private Vector3 velocity = Vector3.zero;

        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
    }

}
