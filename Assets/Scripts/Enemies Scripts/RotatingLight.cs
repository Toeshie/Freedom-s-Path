using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLight : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotationSpeed = 5f;
    
    private Vector3 direction;
    private float rotationAmount;
    private bool rotateRight = true;
    [SerializeField] private float currentRotation = 0f;
    [SerializeField] private float maximumRotation = 180f;
    [SerializeField] private float minumumRotation = 0f;

    private void Update()
    {
        rotationAmount = rotationSpeed * Time.deltaTime;
        
        if (rotateRight)
        {
            transform.RotateAround(pivot.position, Vector3.back, rotationAmount);
            currentRotation += rotationAmount;
            if (currentRotation >= maximumRotation)
            {
                currentRotation = maximumRotation;
                rotateRight = false;
            }
        }
        else
        {
            transform.RotateAround(pivot.position, Vector3.forward, rotationAmount);
            currentRotation -= rotationAmount;
            if (currentRotation <= minumumRotation)
            {
                currentRotation = minumumRotation;
                rotateRight = true;
            }
        }
    }
}
