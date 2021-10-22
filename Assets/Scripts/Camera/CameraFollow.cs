using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraOffSet;
    [SerializeField] private float smoothSpeed; 

   
    void FixedUpdate()
    {
        Vector3 position = player.position + cameraOffSet;
        Vector3 newPosition = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);

        transform.position = newPosition;
    }
}
