using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float turretRotationSpeed = 150;
    public Transform turretParent;
    public TankMovement tankMovement;

    private void Awake()
    {
        if (tankMovement = null) 
            tankMovement = GetComponentInChildren<TankMovement>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }

    public void BodyMovement(Vector2 movementVector)
    {
        tankMovement.Move(movementVector);
    }

    public void TurretMovement(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - turretParent.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) 
            * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, 
            Quaternion.Euler(0, 0, desiredAngle-90), rotationStep);
    }

}
