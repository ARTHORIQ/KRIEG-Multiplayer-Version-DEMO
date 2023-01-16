using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTankMovementData", menuName = "SO Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeed = 120;
    public float rotationSpeed = 55;
    public float acceleration = 80;
    public float deacceleration = 200;
}
