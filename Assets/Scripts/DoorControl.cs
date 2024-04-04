using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    public float openDistance = 5f;
    public Transform doorTransform;
    public float openSpeed = 5f;
    private UnityEngine.Vector3 closedPosition;
    private UnityEngine.Vector3 openPosition;
    public float openAngle = 90.0f;
    private UnityEngine.Quaternion closedRotation;
    private UnityEngine.Quaternion openRotation;

    void Start()
    {
        closedRotation = doorTransform.localRotation;
        openRotation = closedRotation * UnityEngine.Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        float distanceToPlayer = UnityEngine.Vector3.Distance(doorTransform.position, Camera.main.transform.position);

        if (distanceToPlayer < openDistance)
        {
            // Open the door
            doorTransform.localRotation = UnityEngine.Quaternion.Slerp(doorTransform.localRotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            // Close the door
            doorTransform.localRotation = UnityEngine.Quaternion.Slerp(doorTransform.localRotation, closedRotation, Time.deltaTime * openSpeed);
        }
        
    }
}





