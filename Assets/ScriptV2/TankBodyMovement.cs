using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 movementVector;

    public TankMovementData movementData;

    public float currentSpeed = 0;
    public float currentForwardDirection = 1;

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            currentForwardDirection = 1;
        else if (movementVector.y < 0)
            currentForwardDirection = -1;
        else
            currentForwardDirection = 0;

    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.deltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));
    }

}