using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxSpeed = 10;
    public float rotateSpeed = 100;
    private Vector2 movementVector;

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.deltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotateSpeed * Time.fixedDeltaTime));
    }

}
