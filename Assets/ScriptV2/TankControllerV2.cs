using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerV2 : MonoBehaviour
{
    public TankBodyMovement tankbodyMovement;
    public TankAiming tankAiming;
    public TankTurret tankTurret;

    private void Awake()
    {
        if (tankbodyMovement == null)
            tankbodyMovement = GetComponentInChildren<TankBodyMovement>();
        if (tankAiming == null)
            tankAiming = GetComponentInChildren<TankAiming>();
        if (tankTurret == null)
            tankTurret = GetComponentInChildren<TankTurret>();
    }

    public void HandleShoot()
    {
            tankTurret.Shoot();
    }

    public void HandleBodyMove(Vector2 movementVector)
    {
        tankbodyMovement.Move(movementVector);
    }

    public void HandleTurretMove(Vector2 pointerPosition)
    {
        tankAiming.Aim(pointerPosition);
    }
}
