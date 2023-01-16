using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewTankTurretData", menuName ="SO Data/TankTurretData")]
public class TankTurretData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float reloadDelay = 3;
    public BulletData bulletData;
}
